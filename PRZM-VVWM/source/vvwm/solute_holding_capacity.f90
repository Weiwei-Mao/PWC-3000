module solute_capacity


contains
subroutine solute_holding_capacity(chem_index, koc)
   use constants_and_variables, ONLY: fw1,fw2, capacity_1,capacity_2,              &
                                v2,	Sediment_conversion_factor, kd_sed_1,m_sed_1,  &	!out          
                                volume1,theta                                           !INPUT

   use waterbody_PARAMETERs, ONLY: benthic_depth ,porosity,bulk_density,FROC2,DOC2,BNMAS,SUSED, &
           FROC1,DOC1,area_waterbody ,depth_0 ,depth_max,PLMAS               
                                
   !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
   !Calculates the Solute Holding capacity PARAMETER as a vector the size of the simulation 
   !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
  
   implicit none

   REAL, intent(in):: koc
   INTEGER, intent(in)::chem_index
   REAL:: VOL1,VOL2
   REAL:: KOW, KPDOC1,KPDOC2,XKPB

   REAL:: m_sed_2
   REAL:: m_bio_1, m_bio_2
   REAL:: m_doc_1, m_doc_2

   REAL:: kd_sed_2
   REAL:: kd_bio
   REAL:: kd_doc_1, kd_doc_2
INTEGER :: i
   
 !aqueous volumes in each region  
!   v1= daily_depth*area      !total volume in water column, approximately equal to water volume alone
   vol2 = benthic_depth*area_waterbody !total benthic volume
   v2 = vol2*porosity       !with EXAMS PARAMETERs   v2  = VOL2*BULKD*(1.-100./PCTWA)
   
   


!Default EXAMS conditions for partitioning
    KOW = KOC/.35           !DEFAULT EXAMS CONDITION ON Kow  p.35
    KPDOC1= KOW*.074        !DEFAULT RELATION IN EXAMS (LITTORAL)
    KPDOC2 = KOC            !DEFAULT RELATION IN EXAMS (BENTHIC) p.16 of EXAMS 2.98 (or is it Kow*.46 ?)
    XKPB = 0.436*KOW**.907  !DEFAULT RELATION IN EXAMS


! mass in littoral region
    vol1 = depth_0*area_waterbody              !initial volume corresponding with susspended matter reference
    m_sed_1 = SUSED*VOL1*.001        !SEDIMENT MASS LITTORAL
    m_bio_1 = PLMAS*VOL1*.001        !BIOLOGICAL MASS LITTORAL
    m_doc_1 = DOC1*VOL1*.001         !DOC MASS LITTORAL
    

    

! partitioning coefficients of individual media 
    kd_sed_1 = KOC*FROC1*.001       !Kd of sediment in littoral [m3/kg]
    kd_sed_2 = KOC*FROC2*.001       !Kd of sediment in benthic                       
    kd_bio   = XKPB/1000.           !Kd of bioLOGICAL organisms
    kd_doc_1 = KPDOC1/1000.         !Kd of DOC in littoral region
    kd_doc_2 = KPDOC2/1000.         !Kd of DOC in benthic region

! mass in benthic region

    m_sed_2 = bulk_density*VOL2*1000.   ! as defined by EXAMS PARAMETERs m_sed_2 = BULKD/PCTWA*VOL2*100000.
    m_bio_2 = BNMAS*area_waterbody*.001
    m_doc_2 = DOC2*v2*.001


    !solute holding capacity in region 1
    capacity_1 = kd_sed_1 * m_sed_1 + kd_bio * m_bio_1 + kd_doc_1 * m_doc_1 + volume1

    
    !solute holding capacity in region 2
    capacity_2 = kd_sed_2 * m_sed_2 + kd_bio * m_bio_2 + kd_doc_2 * m_doc_2 + v2

	
    fw1=volume1/capacity_1
    fw2=v2/capacity_2
    theta = capacity_2/capacity_1

    
    Sediment_conversion_factor(chem_index) = v2/fw2/m_sed_2  !converts pore water to Total Conc normalized to sed mass
    

end subroutine solute_holding_capacity
end module solute_capacity