module irrigation
    implicit none
    contains
 
      SUBROUTINE IRRIG_PRZM5
!     determines soil moisture deficit, decides if  irrigation is needed, and calculates irrigation depths.

      use  constants_and_Variables, ONLY: precipitation, REALly_not_thrufl,IRTYPE,PCDEPL,max_irrig,FLEACH, &
           IRRR,cint,DELX,theta_end,theta_fc,theta_wp,potential_canopy_holdup,root_node_daily, &
           under_canopy_irrig, over_canopy_irrig, UserSpecifiesDepth,user_irrig_depth_node
      
      implicit none

      REAL     :: SMCRIT,SMAVG,FCAVG,SMDEF
      INTEGER  :: I
      INTEGER  :: local_irrigation_node
      
      SMDEF = 0.0
      REALly_not_thrufl = .FALSE.
!     compute average soil moisture and porosity for root zone

! SMCRIT -- soil moisture level where irrigation begins (fraction).
! SMAVG  -- average root zone soil moisture level (fraction).
! FCAVG  -- average root zone field capacity (fraction).
!
! PCDEPL -- fraction of available water capacity at which irrigation is applied.
!           Usually ~0.45 � 0.55; PRZM accepts values between 0.0 and 0.9
!
! THEFC --  field capacity in the horizon (cm3 cm^-3).
! THEWP --  wilting point in the horizon (cm3 cm^-3).
! THETN --  (cm3 cm^-3) soil water content at the end of the current day for
!           each soil compartment. Note: the water content above the wilting
!           point (ThetN - TheWP) represents the water available to the crop.

! Maximum available soil water:  TheFC - TheWP
! Critical Water Fraction, below which irrigation occurs:  PCDEPL*(TheFC - TheWP)
! Today's available water: Thetn - TheWP
! Therefore, irrigate if: Thetn - TheWP < PCDEPL*(TheFC - TheWP)
!                   i.e., Thetn < PCDEPL*(TheFC - TheWP) + TheWP
!
! From Dirk Young/DC/USEPA/US 10/20/04 12:08 PM
! THETN is actually the begining day water content at this point
! in the program because the call to IRRIG occurs before the
! hydrologic updates in HYDR1. Thus in the IRRIG routine, the
! definition of THETN is contrary to the manual's definition.
!
! See also comments in subroutine iniacc.


      SMCRIT = 0.0
      SMAVG = 0.0
      FCAVG = 0.0
      
      if (UserSpecifiesDepth) THEN
           local_irrigation_node = user_irrig_depth_node 
      else
           local_irrigation_node = root_node_daily
      END IF
      
  
      
      DO I=1,local_irrigation_node
         SMCRIT = SMCRIT + (PCDEPL*(theta_fc(i)-theta_wp(I))+theta_wp(I))*delx(i)
         SMDEF = SMDEF+(theta_fc(i)-theta_end(I))*(1.0 + FLEACH)*DELX(I)
         ! dfy note SMDEF is not the soil moisture deficit, but deficit + salt leaching requirements
         ! not as defined in equation 6-89
      ENDDO

      under_canopy_irrig = 0.0
      over_canopy_irrig = 0.0
      
      IF((Sum(theta_end(1:local_irrigation_node)*delx(1:local_irrigation_node)) > SMCRIT) .OR. precipitation > 0.0) THEN
          IRRR = 0.0
          return !no irrigation needed
      END IF
      
     
     select case (irtype)
      case (1) !Over-Canopy Sprinkler Irrigation;  irrigation applied above the canopy as precipitation 
         !Din is the max holdup possible on the canopy,cint is any water that is on the canopy.  
         !The difference is what is needed to supply canopy demand during overhead irrig
         !Cint is the start-of-day value     
         over_canopy_irrig = MIN(max_irrig , SMDEF + potential_canopy_holdup -CINT)   
         IRRR = over_canopy_irrig
      case (2)
          
      !Under-Canopy Sprinkler Irrigation; irrigation applied as under-canopy throughfall    
         under_canopy_irrig = MIN(max_irrig , SMDEF)
         IRRR=under_canopy_irrig    
      case default
        over_canopy_irrig = 0.0
        IRRR = 0.0
      end select

    END SUBROUTINE IRRIG_PRZM5

        
end module irrigation
    