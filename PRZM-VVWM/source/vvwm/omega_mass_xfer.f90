module mass_transfer

contains
subroutine omega_mass_xfer
!This subroutine calculates the littoral to benthic mass transfer coefficient
use constants_and_variables, ONLY: omega 
use waterbody_PARAMETERs, ONLY: D_over_dx, benthic_depth


implicit none
  

!REAL :: CHARL

!According to EFED standard practice, the PARAMETER CHARL is one half the sum
!of the distance between benthic and water column midpoints.  D. Young has 
!raised issues with this (see SAP 2004 document).  In the mean time, the omega value
!will remain constant at the initial value as determined by current EFED practice
!as defined here.  Better estimates should be looked in to:

!charl = 0.5*(benthic_depth + depth_0)

! charl = massXferLENgth  !user input for mass transfer LENgth


!Note: in EXAMS, DSP is a total dispersion coefficient
!based on total volume in benthic region

omega = D_over_dx/benthic_depth !(m3/hr)/(3600 s/hr)



end subroutine omega_mass_xfer

end module mass_transfer