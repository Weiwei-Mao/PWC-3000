module process_medians
    implicit none
    
    
    contains
    
    subroutine calculate_medians(app_window_counter, run_tpez_wpez)
          use constants_and_variables, ONLY: nchem, number_medians, hold_for_medians_wb, hold_for_medians_wpez, hold_for_medians_tpez,  &
              hold_for_medians_daughter, hold_for_medians_grandaughter, hold_for_medians_WPEZ_daughter, hold_for_medians_TPEZ_daughter, &
              hold_for_medians_WPEZ_grandaughter,hold_for_medians_TPEZ_grandaughter , &
              First_time_through_medians,median_unit,run_id, &
              median_daughter_unit,median_grandaughter_unit ,median_unit_wpez, median_unit_tpez,median_daughter_unit_wpez,median_grandaughter_unit_wpez,&
              median_daughter_unit_tpez,median_grandaughter_unit_tpez, Sediment_conversion_factor, family_name, working_directory
            
          use utilities_1, ONLY: find_medians
          use waterbody_PARAMETERs, ONLY: this_waterbody_name
          
          
          INTEGER, intent(in) :: app_window_counter
          LOGICAL, intent(in) :: run_tpez_wpez
    
          INTEGER :: i
          REAL    :: medians_temp(number_medians)        
          CHARACTER(LEN=1000) :: localfiLEName
          
          
          !***** Open median file and WRITE headers*******
 
          if (First_time_through_medians) THEN 
              !open a file and WRITE header
               localfiLEName = trim(working_directory) //trim(family_name) // "_medians_" // trim(this_waterbody_name) // ".txt"
               open (UNIT= median_unit, FILE = localfiLEName, STATUS = 'UNKNOWN')
               WRITE(median_unit, '(''Benthic Conversion Factor             = '', G14.4E3,'' -Pore water (ug/L) to (total mass, ug)/(dry sed mass,kg)'')') Sediment_conversion_factor(1)*1000.        
               WRITE(median_unit, '(A225)') (("Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg, post_bt_avg,  throughput,  GWpeak"))

               if (nchem>1) THEN !daughter
                   localfiLEName = trim(working_directory) //trim(family_name) //  "_medians_deg1_" // trim(this_waterbody_name) // ".txt"
                   open (UNIT= median_daughter_unit, FILE = localfiLEName, STATUS = 'UNKNOWN')
                   
                   WRITE(median_daughter_unit, '(''Benthic Conversion Factor             = '', G14.4E3,'' -Pore water (ug/L) to (total mass, ug)/(dry sed mass,kg)'')') Sediment_conversion_factor(2)*1000.
                   WRITE(median_daughter_unit, '(A225)') (("Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg, post_bt_avg,  throughput, GWpeak"))
               endif
               
               if (nchem>2) THEN !grandaughter
                   localfiLEName =  trim(working_directory) //trim(family_name) // "_medians_deg2_" // trim(this_waterbody_name) // ".txt"
                   open (UNIT= median_grandaughter_unit, FILE = localfiLEName, STATUS = 'UNKNOWN')
                   WRITE(median_grandaughter_unit, '(''Benthic Conversion Factor             = '', G14.4E3,'' -Pore water (ug/L) to (total mass, ug)/(dry sed mass,kg)'')') Sediment_conversion_factor(3)*1000.
                   
                   WRITE(median_grandaughter_unit, '(A225)') (("Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg, post_bt_avg,  throughput, GWpeak"))
               endif

               if (run_tpez_wpez) THEN
                  localfiLEName = trim(working_directory) //trim(family_name) // '_medians_wpez.txt'
                  open (UNIT= median_unit_wpez, FILE = localfiLEName, STATUS = 'UNKNOWN')
                  WRITE(median_unit_wpez,  '(A212)') "Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg,  Total System (lb/A)"

                  localfiLEName = trim(working_directory) //trim(family_name) // '_medians_tpez.txt'
                  open (UNIT= median_unit_tpez, FILE = localfiLEName, STATUS = 'UNKNOWN')
                  WRITE(median_unit_tpez,  '(A93)') "Run Information                                                                       ,  lb/A"

                  if (nchem>1) THEN !daughter
                      localfiLEName = trim(working_directory) //trim(family_name) // '_medians_deg1_wpez.txt'
                      open (UNIT= median_daughter_unit_wpez, FILE = localfiLEName, STATUS = 'UNKNOWN')
                      WRITE(median_daughter_unit_wpez,  '(A212)') "Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg,  Total System (lb/A)"

                      localfiLEName = trim(working_directory) //trim(family_name) // '_medians_deg1_tpez.txt'
                      open (UNIT= median_daughter_unit_tpez, FILE = localfiLEName, STATUS = 'UNKNOWN')
                      WRITE(median_daughter_unit_tpez,  '(A93)') "Run Information                                                                       ,  lb/A"

                  endif
                  
                  
                  if (nchem>2) THEN !grandaughter
                      localfiLEName =  trim(working_directory) //trim(family_name) // '_medians_deg2_wpez.txt'
                      open (UNIT= median_grandaughter_unit_wpez, FILE = localfiLEName, STATUS = 'UNKNOWN')
                      WRITE(median_grandaughter_unit_wpez,  '(A212)') "Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg,  Total System (lb/A)"

                      localfiLEName = trim(working_directory) // trim(family_name) // '_medians_deg2_tpez.txt'
                      open (UNIT= median_grandaughter_unit_tpez, FILE = localfiLEName, STATUS = 'UNKNOWN')
                      WRITE(median_grandaughter_unit_tpez,  '(A93)') "Run Information                                                                       ,  lb/A"

                  endif
                  
                  

               END IF
               
   
               
               First_time_through_medians = .FALSE.
          END IF
               
 
          !*********Populate Open Median Files with Data************

          call find_medians (app_window_counter, number_medians, hold_for_medians_wb, medians_temp)             
          WRITE(median_unit, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, number_medians)  

          if (nchem>1) THEN !daughter
              call find_medians (app_window_counter, number_medians, hold_for_medians_daughter, medians_temp)             
              WRITE(median_daughter_unit, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, number_medians)  
          END IF
          
          if (nchem>2) THEN !grandaughter
              call find_medians (app_window_counter, number_medians, hold_for_medians_grandaughter, medians_temp)             
              WRITE(median_grandaughter_unit, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, number_medians)  
          END IF
          

          
          !*******************************************
          

         if (run_tpez_wpez) THEN  !wpez needs its own call due to different capture also because its scenario run is same as pond                 

           
             call find_medians (app_window_counter, number_medians, hold_for_medians_wpez, medians_temp)  
                
  
                WRITE(median_unit_wpez, '(A86, 10(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, 9) 

   
                call find_medians (app_window_counter, 1, hold_for_medians_tpez, medians_temp)   
                WRITE(median_unit_tpez, '(A86, ",", G12.4 )') adjustl((adjustr(run_id)//"_median")), medians_temp(1)*0.892179
    

                if (nchem>1) THEN !daughter
     
                   call find_medians (app_window_counter, number_medians, hold_for_medians_WPEZ_daughter, medians_temp)             
                   WRITE(median_daughter_unit_wpez, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, number_medians)  
           
                   call find_medians (app_window_counter, 1, hold_for_medians_TPEZ_daughter, medians_temp)             
                   WRITE(median_daughter_unit_tpez, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), medians_temp(1)*0.892179
                END IF
                 
          
               if (nchem>2) THEN !grandaughter
                   call find_medians (app_window_counter, number_medians, hold_for_medians_WPEZ_grandaughter, medians_temp)             
                   WRITE(median_grandaughter_unit_wpez, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, number_medians)  
           
                   call find_medians (app_window_counter, 1, hold_for_medians_TPEZ_grandaughter, medians_temp)             
                   WRITE(median_grandaughter_unit_tpez, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), medians_temp(1)*0.892179
               END IF
               
         END IF
         
               
               
    end subroutine calculate_medians
    

end module process_medians
    