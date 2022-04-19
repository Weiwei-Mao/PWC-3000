module outputprocessing

    contains
    

    subroutine output_processor(chem_index)
    use utilities
  !  use variables
    use waterbody_parameters, ONLY: baseflow,SimTypeFlag
    
    use constants_and_variables, ONLY:  num_records, run_id, is_hed_files_made,is_add_return_frequency, additional_return_frequency, &
                                       num_years, startday,  waterbodytext, &
                                 gamma_1,        &
                                 gamma_2,        &
                                 fw1,            &
                                 fw2,            &
                                 aq1_store,      &   !beginning day after app concentration in water column
                                 aq2_store,      &
                                 aqconc_avg1,    &   !average daily concentration (after app)
                                 aqconc_avg2,    &
                                 daily_depth,    &
                                 runoff_total ,  &
                                 erosion_total,  &
                                 spray_total ,   &
                                 Daily_Avg_Runoff, Daily_avg_flow_out,  runoff_fraction, erosion_fraction, drift_fraction ,&
    k_burial, k_aer_aq, k_flow, k_hydro, k_photo, k_volatile,k_anaer_aq, gamma_1, gamma_2, gw_peak, post_bt_avg ,throughputs,simulation_avg, &
		is_waterbody_info_output, full_run_identification
   
                         
    implicit none
    integer, intent(in) :: chem_index
    character(len=512) :: waterbody_outputfile
    
    !temporary parameters for esa, should make this more generalk in the future
    real:: return_frequency
    integer:: unit_number
    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    
    real:: simulation_average
    
    real :: xxx  !local variable

 !   real(8),dimension(num_records)::c1
 !   real(8),dimension(num_records)::cavgw


    real,dimension(num_records):: c4        !all 4-day averaged values
    real,dimension(num_records):: c21
    real,dimension(num_records):: c60
    real,dimension(num_records):: c90
    real,dimension(num_records):: c365
    real,dimension(num_records):: benthic_c21
    
    real,dimension(num_years):: onedayavg
    real,dimension(num_years):: peak   
    real,dimension(num_years):: benthic_peak
    
    
    real,dimension(num_years):: c1_max  !peak year to year daily average
    
    real,dimension(num_years):: c4_max  !the peak 4-day average within the 365 days after application
    real,dimension(num_years):: c21_max
    real,dimension(num_years):: c60_max
    real, dimension(num_years)::c90_max
    real,dimension(num_years):: c365_max !the peak 365-day average within the 365 days after application
                                            !last year will be short depending on application date
                                        
    real,dimension(num_years):: benthic_c21_max                         
                                        
    integer :: i    
    integer ::date_time(8)
    real :: convert                    !conversion factor kg/m3 

    real :: Total_Mass
    integer :: YEAR,MONTH,DAY
    integer :: eliminate_year
    
    
    ! No longer using first app as the first day
    
    integer,dimension(num_years) ::  first_annual_dates !array of yearly first dates (absolute days).
                                    ! First date is the calendar day of start of simulation 
    first_annual_dates= 0
    

if (is_waterbody_info_output) then
	select case (chem_index)

		
	    case (1)
		    waterbody_outputfile = trim(full_run_identification) // '_parent_wb.out'
	    case (2)
		    waterbody_outputfile = trim(full_run_identification) // '_daugter_wb.out'
	    case (3)
		    waterbody_outputfile = trim(full_run_identification) // '_granddaugter_wb.out'		
	    case default
		    waterbody_outputfile =trim(full_run_identification) // '_nada.out'	
	end select
	
	open (UNIT=12,FILE= trim(waterbody_outputfile),  STATUS='unknown')

    do i =1, num_records
        write(12,'(G12.4E3, "," ,ES12.4E3, "," ,ES12.4E3, "," ,ES12.4E3)')  daily_depth(i), aqconc_avg1(i), aqconc_avg2(i)
	end do
	close (12)
end if


!
!    !***** EFED TIME SERIES ********************************************
!    write(12,*) "col 1: Daily Depth (m)" 
!    write(12,*) "col 2: Daily Average Aqueous Conc. in Water Columm, kg/m3 "
!    write(12,*) "col 3: Daily Average Aqueous Conc. in Benthic Zone, kg/m3"
!    write(12,*) "col 4: Daily Peak Aqueous Conc. in Water Column, kg/m3"
!    
!    write(12,*)  startday, "= Start Day (number of days since 1900)"
!    do i =1, num_records
!         write(12,'(G12.4E3, "," ,ES12.4E3, "," ,ES12.4E3, "," ,ES12.4E3)')  daily_depth(i), aqconc_avg1(i), aqconc_avg2(i), aq1_store(i) 
!    end do
!    
!    !******HED TIME SERIES **************************************
!    if (SimTypeFlag /=2  .and. is_hed_files_made) then  !No need for Calendex and DEEM for Pond
!        !************************  DEEM Input File Header ********************************
!        write(22,*) "'DEEM Input File" 
!        write(22,'(" ''Performed on: ", i2,"/",i2,"/",i4,2x,"at " ,i2,":",i2) ') &
!                       date_time(2),date_time(3),date_time(1),date_time(5),date_time(6)
!        write(22,*) "'Scenario: ", trim(scenario_id)," " ,trim( waterbodytext)
!        write(22,*) "'List of Daily Average Aqueous Concentration in Water Columm, mg/L "
!        write(22,*) "'Start data:"
!        
!        !************************  CALENDEX & DEEM DATA Input ********************************  
!        call get_date (startday, YEAR,MONTH,DAY)
!        eliminate_year = year
!        
!        do i =1, num_records
!             call get_date (startday+i-1, YEAR,MONTH,DAY)
!            if (year > eliminate_year) then 
!                write(22,'(ES15.4)')  aqconc_avg1(i)*1000.0   !DEEM FILE DATA
!            !    write(23,'(I2.2,"/",I2.2,"/", I4, "," ,ES15.4E3)')  month,day, year, aqconc_avg1(i)*1000.0   !Calendex File Data   
!            end if    
!        end do
!    end if
!    !**************************************************************************
!end if

    write(*,*) 'Start Window averaging'
    !Calculate chronic values *******************
    !The following returns the n-day running averages for each day in simulation
   
    call window_average(aqconc_avg1,4,num_records,c4)
    call window_average(aqconc_avg1,21,num_records,c21)
    call window_average(aqconc_avg1,60,num_records,c60)
    call window_average(aqconc_avg1,90,num_records,c90)  
    call window_average(aqconc_avg1,365,num_records,c365)

    Simulation_average = sum(aqconc_avg1)/num_records
    
    call window_average(aqconc_avg2,21,num_records,benthic_c21)

    call find_first_annual_dates (num_years, first_annual_dates )

	 write(*,*) 'Start picking max'
	
	

	 
    call pick_max(num_years,num_records, first_annual_dates,aqconc_avg1,c1_max) !NEW FIND DAILY AVERAGE CONCENTRATION RETURN   
    call pick_max(num_years,num_records, first_annual_dates,c4,c4_max)
    call pick_max(num_years,num_records, first_annual_dates,c21,c21_max)
    call pick_max(num_years,num_records, first_annual_dates,c60,c60_max)
    call pick_max(num_years,num_records, first_annual_dates,c90,c90_max)
    call pick_max(num_years,num_records, first_annual_dates,benthic_c21,benthic_c21_max)

    !treat the 365 day average somewhat differently:
    !In this case, we simply are calculating the average for the 365 day forward from the
    !day of application
 
    do concurrent (i=1:num_years-1) 
        c365_max(i) = c365(first_annual_dates(i)+365)  
    end do
    
    c365_max(num_years) = c365(num_records)

    !****Calculate Acute values *******************
    call pick_max(num_years,num_records, first_annual_dates,aq1_store, peak)    
    call pick_max(num_years,num_records, first_annual_dates,aq2_store, benthic_peak)
    
    !*****************************************

    convert = 1000000.
    peak               = peak*convert
    c1_max             = c1_max*convert
    c4_max             = c4_max*convert
    c21_max            = c21_max*convert
    c60_max            = c60_max*convert
    c90_max            = c90_max*convert
    c365_max           = c365_max*convert
    benthic_peak       = benthic_peak*convert
    benthic_c21_max    = benthic_c21_max*convert
    Simulation_average = Simulation_average*convert


 !   if (is_output_all== .false.) then  !append an output file for a reduced output batch run
       return_frequency = 10.0
       

 
 
        Total_Mass = runoff_total(chem_index) + erosion_total(chem_index) +  spray_total(chem_index)        
        If (Total_Mass <= 0.0) then
            runoff_fraction  = 0.0
            erosion_fraction = 0.0
            drift_fraction   = 0.0
        else
            runoff_fraction  = runoff_total(chem_index) /Total_Mass
            erosion_fraction = erosion_total(chem_index) /Total_Mass
            drift_fraction   =  spray_total(chem_index)/Total_Mass
        end if
      write(*,*) 'Doing output process'  
       call calculate_effective_halflives()
       
	   
	   
	   
       call write_simple_batch_data(chem_index, return_frequency,num_years, peak,Simulation_average,c1_max,c4_max,c21_max,c60_max,c90_max,c365_max,benthic_peak, benthic_c21_max )      
  !  else        
       !
       ! if (is_add_return_frequency) then 
       !return_frequency = additional_return_frequency
       !unit_number = 33
       !call write_returnfrequency_data(return_frequency, unit_number,num_years, peak,Simulation_average,c1_max,c4_max,c21_max,c60_max,c90_max,c365_max,benthic_peak, benthic_c21_max )
       ! end if
       ! 
       ! return_frequency = 10.0
       ! unit_number = 11
       !
       ! call write_returnfrequency_data(return_frequency, unit_number,num_years, peak,Simulation_average,c1_max,c4_max,c21_max,c60_max,c90_max,c365_max,benthic_peak, benthic_c21_max )
     
 
       ! write (11,*) "***********************************************************************"
       ! write (11,*)  "Flow in/out Characteristics of Waterbody:"
       ! Write (11,*)  "Average Daily Runoff Into Waterbody (m3/s) = " , Daily_Avg_Runoff
       ! Write (11,*)  "Baseflow Into Waterbody (m3/s)             = " , baseflow
       ! Write (11,*)  "Average Daily Flow Out of Waterbody (m3/s) = " , Daily_avg_flow_out
 !   end if 

    end subroutine output_processor



!***************************************************************
subroutine pick_max (num_years,num_records,bounds,c, output)
!    !this subroutine choses the maximum values of subsets of the vector c
!    !the subsets are defined by the vector "bounds"
!    !maximum values of "c" are chosen from within the c indices defined by "bounds"
!    !output is delivered in the vector "output"
    implicit none
    integer, intent(in) :: num_records
    integer, intent(in) :: num_years
    integer, intent(in) :: bounds(num_years)
    real, intent(in), dimension(num_records) :: c
    real, intent(out),dimension(num_years) :: output

    integer :: i

    !forall (i = 1: num_years-1) output(i) = maxval( c(bounds(i):bounds(i+1)-1) ) changed 2/5/2020
    
    
    
    do concurrent(i = 1: num_years-1)
        output(i) = maxval( c(bounds(i):bounds(i+1)-1) )
    end do
    
    output(num_years)= maxval( c(bounds(num_years):num_records) )

    
    
end subroutine pick_max

!***************************************************************
subroutine Return_Frequency_Value(returnfrequency, c_in, n, c_out, lowYearFlag)
    !CALCULATES THE Concentration at the given yearly return frequency
    implicit none
    
    real,intent(in) :: returnfrequency             !Example 1 in 10 years would be 10.0
    integer,intent(in) :: n                        !number of items in list
    real, intent(in), dimension(n):: c_in          !list of items
    
    real,intent(out):: c_out                       !output of 90th centile of peaks
    real:: f,DEC      
    integer:: m    
    real,dimension(n):: c_sorted
    logical, intent(out) :: LowYearFlag  !if n is less than 10, returns max value and LowYearFlag =1
    LowYearFlag = .false.

    call hpsort(n,c_sorted, c_in)  !returns a sorted array
    
    f = (1.0 -1.0/returnfrequency )*(n+1)
    m=int(f)
    DEC = f-m      
    
   if (n < returnfrequency)then
      c_out = c_sorted(n)
      LowYearFlag = .true.
   else 
    c_out = c_sorted(m)+DEC*(c_sorted(m+1)-c_sorted(m))
   end if

end subroutine Return_Frequency_Value
!***************************************************************
!****************************************************************
subroutine hpsort(n,ra,b)
!  from numerical recipes  (should be upgraded to new f90 routine)
    implicit none
    integer,intent(in):: n
    real,intent(out),dimension(n)::ra !ordered output array
    real,intent(in),dimension(n):: b  !original unordered input array

    integer i,ir,j,l
    real rra
    
    ra=b    ! this added to conserve original order

    if (n.lt.2) return

    l=n/2+1
    ir=n
10    continue
    if(l.gt.1)then 
    l=l-1
    rra=ra(l)
    else 
    rra=ra(ir)    
    ra(ir)=ra(1)
    ir=ir-1
    if(ir.eq.1)then 
    ra(1)=rra 
    return
    endif
    endif
    i=l 
    j=l+l
20    if(j.le.ir)then 
        if(j.lt.ir)then
            if(ra(j).lt.ra(j+1))j=j+1 
        endif
        if(rra.lt.ra(j))then 
            ra(i)=ra(j)
            i=j
            j=j+j
        else 
            j=ir+1
        endif
        goto 20
        endif
    ra(i)=rra
    goto 10
end subroutine hpsort
!*******************************************************************************
!*******************************************************************************
subroutine find_first_annual_dates(num_years, first_annual_dates )
   use constants_and_variables, ONLY: first_year, first_mon, first_day, startday
   use utilities
   implicit none
   
   integer,intent(in) :: num_years
   integer,intent(out),dimension(num_years) :: first_annual_dates
   integer i

   do i = 1,num_years
      first_annual_dates(i) =  jd(first_year+(i-1), first_mon,first_day )    
   end do

   first_annual_dates = first_annual_dates - startday+1

end subroutine find_first_annual_dates
!********************************************************************************



 subroutine write_returnfrequency_data(return_frequency, unit_number,num_years, peak,Simulation_average,c1_max,c4_max,c21_max,c60_max,c90_max,c365_max,benthic_peak, benthic_c21_max   )
   use constants_and_variables, Only : version_number,Sediment_conversion_factor,fw2 

   implicit none
  
     real, intent(in)                         :: return_frequency
     integer, intent(in)                       :: unit_number
     integer, intent(in)                       :: num_years
     real   , intent(in), dimension(num_years) :: peak,c1_max,c4_max,c21_max,c60_max,c90_max,c365_max,benthic_peak, benthic_c21_max
     real, intent(in)                          :: Simulation_average
     
     
     real :: peak_out,c1_out, c4_out,c21_out,c60_out,c90_out,c365_out,benthic_peak_out,benthic_c21_out
     logical :: lowyearflag
     integer :: date_time(8)
     integer :: i
     character(len=10) :: frequencystring 

  
     !**find values corresponding to  percentiles
     call Return_Frequency_Value(return_frequency, peak,           num_years, peak_out,         lowyearflag)
     
     call Return_Frequency_Value(return_frequency, c1_max,         num_years, c1_out,           lowyearflag)
     
     call Return_Frequency_Value(return_frequency, c4_max,         num_years, c4_out,           lowyearflag)
     call Return_Frequency_Value(return_frequency, c21_max,        num_years, c21_out,          lowyearflag)
     call Return_Frequency_Value(return_frequency, c60_max,        num_years, c60_out,          lowyearflag)
     call Return_Frequency_Value(return_frequency, c90_max,        num_years, c90_out,          lowyearflag)
     call Return_Frequency_Value(return_frequency, c365_max,       num_years, c365_out,         lowyearflag)
     call Return_Frequency_Value(return_frequency, benthic_peak,   num_years, benthic_peak_out, lowyearflag)
     call Return_Frequency_Value(return_frequency, benthic_c21_max,num_years, benthic_c21_out,  lowyearflag)
    

    call date_and_time(VALUES = date_time)
    
    Write(unit_number,*) "Waterbody Output, PRZMVVWM Version ", Version_Number
  
    write(unit_number,*) 
    write(unit_number,*)  '*******************************************'
    write(unit_number,'("Performed on: ", i2,"/",i2,"/",i4,2x,"at " ,i2,":",i2) ') &
                   date_time(2),date_time(3),date_time(1),date_time(5),date_time(6)
  
    write(frequencystring, '(F4.1)')  return_frequency  !internal write in order to right justify string
  

  
  if (LowYearFlag)then
      Write(unit_number,  '(''* Insufficient years to calculate 1-in-'', A5, ''. Only maximums are reported here.'') '   ) adjustl(frequencystring)
  else 
       write(unit_number,*)
  end if
 
 ! write(unit_number, '(''Initial 1-in-'', A5 ,'' = '', G14.4E3,'' ppb'')'  )    adjustl(frequencystring), peak_out
  write(unit_number, '(''1-d avg   1-in-'', A5 ,'' = '', G14.4E3,'' ppb'')'  )    adjustl(frequencystring),c1_out
  write(unit_number, '(''365-d avg 1-in-'', A5 ,'' = '', G14.4E3,'' ppb'')'  )    adjustl(frequencystring),c365_out 
  write(unit_number, '(''Simulation Avg       = '', G14.4E3,'' ppb'')'  )         simulation_average
  write(unit_number, '(''4-d avg  1-in-'', A5 ,''  = '', G14.4E3,'' ppb'')'  )  adjustl(frequencystring),c4_out
  write(unit_number, '(''21-d avg 1-in-'', A5 ,''  = '', G14.4E3,'' ppb'')'  )  adjustl(frequencystring), c21_out
  write(unit_number, '(''60-d avg 1-in-'', A5 ,''  = '', G14.4E3,'' ppb'')'  )  adjustl(frequencystring), c60_out
  write(unit_number, '(''90-d avg 1-in-'', A5 ,''  = '', G14.4E3,'' ppb'')'  )  adjustl(frequencystring),c90_out
  
  
    
  write(unit_number, '(''Benthic Pore Water 1-d  avg 1-in-'', A5 ,''= '', G14.4E3,'' ppb'')'  ) adjustl(frequencystring),  benthic_peak_out
  write(unit_number, '(''Benthic Pore Water 21-d avg 1-in-'', A5 ,''= '', G14.4E3,'' ppb'')'  ) adjustl(frequencystring),  benthic_c21_out
    
  write(unit_number, '(''Benthic Conversion Factor             = '', G14.4E3,'' -Pore water (ug/L) to (total mass, ug)/(dry sed mass,kg)'')')&
        Sediment_conversion_factor*1000.
  
  write(unit_number, '(''Benthic Mass Fraction in Pore Water   = '', G14.4E3)'  )  fw2
  write (unit_number,*)
  write (unit_number,'(A)') 'YEAR    1-day     4-day      21-day     60-day     90-day   Yearly Avg Benthic Pk  Benthic 21-day'
  do I=1, num_years  
   write(unit_number,'(I3,1x,8ES11.2E3)') i,c1_max(i),c4_max(i),c21_max(i),c60_max(i),c90_max(i),c365_max(i),benthic_peak(i),benthic_c21_max(i)
  end do
  

 end subroutine write_returnfrequency_data
 




subroutine write_simple_batch_data(chem_index, return_frequency,num_years, peak,Simulation_average,c1_max,c4_max,c21_max,c60_max,c90_max,c365_max,benthic_peak, benthic_c21_max   )

use constants_and_variables, ONLY: run_id,Sediment_conversion_factor,fw2 ,&
     nchem,     runoff_fraction,erosion_fraction,drift_fraction , First_time_through,summary_outputfile,summary_output_unit, &
 effective_washout, effective_watercol_metab, effective_hydrolysis, effective_photolysis, effective_volatization, effective_total_deg1,&
    effective_burial, effective_benthic_metab, effective_benthic_hydrolysis, effective_total_deg2, &
    summary_output_unit_deg1, summary_output_unit_deg2, summary_outputfile_deg1, summary_outputfile_deg2, gw_peak, post_bt_avg ,throughputs,simulation_avg

    implicit none   
   ! integer, intent(in)                       :: unit_number
    integer, intent(in)                       :: num_years
    real, intent(in)                          :: return_frequency
    real, intent(in), dimension(num_years)    :: peak,c1_max,c4_max,c21_max,c60_max,c90_max,c365_max,benthic_peak, benthic_c21_max
    real, intent(in)                          :: Simulation_average
    integer, intent(in) ::chem_index
    character (len=400) :: header
    
    
    !****LOCAL*********************
    real      :: peak_out,c1_out, c4_out,c21_out,c60_out,c90_out,c365_out,benthic_peak_out,benthic_c21_out    
    logical   :: lowyearflag
    character(len= 257) :: local_run_id
    
    If (First_time_through) then
        header = 'Run Information                                      1-d avg      365-d avg    Total avg    4-d avg      21-d avg     60-d avg     B 1-day      B 21-d avg   Runoff Frac  Erosn Frac   Drift Frac   col washout  col metab    col hydro    col photo    col volat    col total    ben sed rem  ben metab    ben hydro    ben total     gw_peak     post_bt_avg  throughput'
        
        Open(unit=summary_output_unit,FILE= trim(summary_outputfile),Status='unknown')  
        Write(summary_output_unit, '(A400)') header
        if ( NCHEM>1) then
            Open(unit=summary_output_unit_deg1,FILE= trim(summary_outputfile_deg1),Status='unknown')  
            Write(summary_output_unit_deg1, '(A322)') header
        end if
        if ( NCHEM >2) then
            Open(unit=summary_output_unit_deg2,FILE= trim(summary_outputfile_deg2),Status='unknown')  
            Write(summary_output_unit_deg1, '(A322)') header
        end if
        
        First_time_through= .FALSE.
    end if


    !**find values corresponding to  percentiles
    call Return_Frequency_Value(return_frequency, peak,           num_years, peak_out,         lowyearflag)   
    call Return_Frequency_Value(return_frequency, c1_max,         num_years, c1_out,           lowyearflag)
    
    call Return_Frequency_Value(return_frequency, c4_max,         num_years, c4_out,           lowyearflag)
    call Return_Frequency_Value(return_frequency, c21_max,        num_years, c21_out,          lowyearflag)
    call Return_Frequency_Value(return_frequency, c60_max,        num_years, c60_out,          lowyearflag)
    !call Return_Frequency_Value(return_frequency, c90_max,        num_years, c90_out,          lowyearflag)
    call Return_Frequency_Value(return_frequency, c365_max,       num_years, c365_out,         lowyearflag)
    call Return_Frequency_Value(return_frequency, benthic_peak,   num_years, benthic_peak_out, lowyearflag)
    call Return_Frequency_Value(return_frequency, benthic_c21_max,num_years, benthic_c21_out,  lowyearflag)

	

    select case (chem_index)
    case (1)
        local_run_id = trim(run_id) // '_Parent'
        write(summary_output_unit,'(A50,1x,25ES13.4E3)') (adjustl(local_run_id)), c1_out, c365_out , simulation_average, c4_out, c21_out,c60_out,benthic_peak_out, benthic_c21_out,runoff_fraction,erosion_fraction,drift_fraction, &
        effective_washout, effective_watercol_metab, effective_hydrolysis, effective_photolysis, effective_volatization, effective_total_deg1, effective_burial, effective_benthic_metab, effective_benthic_hydrolysis, effective_total_deg2, gw_peak, post_bt_avg ,throughputs

    case (2)
        local_run_id = trim(run_id) // '_deg1'
        write(summary_output_unit_deg1,'(A50,1x,22ES13.4E3)') (adjustl(local_run_id)), c1_out, c365_out , simulation_average, c4_out, c21_out,c60_out,benthic_peak_out, benthic_c21_out,runoff_fraction,erosion_fraction,drift_fraction, &
        effective_washout, effective_watercol_metab, effective_hydrolysis, effective_photolysis, effective_volatization, effective_total_deg1, effective_burial, effective_benthic_metab, effective_benthic_hydrolysis, effective_total_deg2
    case (3)
        local_run_id = trim(run_id)  // '_deg2'
        write(summary_output_unit_deg2,'(A50,1x,22ES13.4E3)') (adjustl(local_run_id)), c1_out, c365_out , simulation_average, c4_out, c21_out,c60_out,benthic_peak_out, benthic_c21_out,runoff_fraction,erosion_fraction,drift_fraction, &
        effective_washout, effective_watercol_metab, effective_hydrolysis, effective_photolysis, effective_volatization, effective_total_deg1, effective_burial, effective_benthic_metab, effective_benthic_hydrolysis, effective_total_deg2

        case default
    end select


    
 write(*,*)'done output batch '
     
 end subroutine write_simple_batch_data




Subroutine calculate_effective_halflives()
!Effective compartment halflives averaged over simulation duration:
use constants_and_variables, ONLY: num_records, k_burial, k_aer_aq, k_flow, k_hydro, k_photo, k_volatile,k_anaer_aq, gamma_1, gamma_2, fw1, fw2, &
    effective_washout, effective_watercol_metab, effective_hydrolysis, effective_photolysis, effective_volatization, effective_total_deg1, effective_burial, effective_benthic_metab, effective_benthic_hydrolysis, effective_total_deg2

implicit none
real :: xxx

        xxx = sum(k_flow)
        if (xxx > 0.) then
            effective_washout= 0.69314/(xxx/num_records)/86400
        else
            effective_washout = 0.
        end if                      
       
        xxx = sum(k_aer_aq)
        if (xxx > 0.) then
            effective_watercol_metab =  0.69314/(xxx/num_records)/86400
        else
            effective_watercol_metab = 0.0
        end if
       
        xxx = sum(k_hydro*fw1)  
        if (xxx > 0.) then
            effective_hydrolysis = 0.69314/(xxx/num_records)/86400
        else
            effective_hydrolysis= 0.0
        end if
       
        xxx =  sum(k_photo*fw1)
        if (xxx > 0.) then
            effective_photolysis =  0.69314/(xxx/num_records)/86400
        else
            effective_photolysis = 0.0
        end if       
       
        xxx =  sum(k_volatile*fw1)
        if (xxx > 0.) then
           effective_volatization =  0.69314/(xxx/num_records)/86400
        else
           effective_volatization = 0.0
        end if      
        
        xxx =  sum(gamma_1)
        if (xxx > 0.) then
            effective_total_deg1 =  0.69314/(xxx/num_records)/86400
        else
            effective_total_deg1 = 0.0
        end if    
        
       
        xxx = sum(k_burial)
        if (xxx > 0.) then
             effective_burial =  0.69314/(xxx/num_records)/86400
        else
             effective_burial = 0.0
        end if
       
        xxx = sum(k_anaer_aq)
        if (xxx > 0.) then
           effective_benthic_metab =  0.69314/(xxx/num_records)/86400
        else
           effective_benthic_metab = 0.0
        end if
        
        xxx = sum(k_hydro*fw2)
        if (xxx > 0.) then
           effective_benthic_hydrolysis =  0.69314/(xxx/num_records)/86400
        else
           effective_benthic_hydrolysis = 0.0
        end if 
       
       
        xxx = sum(gamma_2)
        if (xxx > 0.) then
            effective_total_deg2 = 0.69314/(xxx/num_records)/86400
        else
            effective_total_deg2 = 0.0
        end if 


end Subroutine calculate_effective_halflives





end module outputprocessing