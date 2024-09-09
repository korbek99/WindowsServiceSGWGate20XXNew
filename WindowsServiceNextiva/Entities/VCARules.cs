using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsServiceNextiva.Entities
{
   public class VCARules
    {
        
            public int VCA_CMD_SET_CHANNEL_ID = 0;           // Set VCA Channel Number and Enable
            public int VCA_CMD_SET_VIDEOSIZE_ID = 1;           // Set VCA Channel of video size
            public int VCA_CMD_SET_ADVANCE_PARAM_ID = 2;       // Set VCA advanced parameter
            public int VCA_CMD_SET_TARGET_PARAM_ID = 3;        // Set VCA superimpose paramenter and colour setting
            public int VCA_CMD_SET_ALARM_STATISTIC_ID = 4;     // Set VCA alarm count is zero
            public int VCA_CMD_SET_RULE_COMMON_ID = 5;         // Set rule of VCA convention parameter
            public int VCA_CMD_SET_RULE0_TRIPWIRE_ID = 6;      // Set rule of VCA(single tripwire)
            public int VCA_CMD_SET_RULE1_DBTRIPWIRE_ID = 7;    // Set rule of VCA(double tripwire)
            public int VCA_CMD_SET_RULE2_PERIMETER_ID = 8;     // Set rule of VCA(perimeter)
            public int VCA_CMD_SET_ALARM_SCHEDULE_ID = 9;      // Set VCA alarm module
            public int VCA_CMD_SET_ALARM_LINK_ID = 10;         // Set VCA input port
            public int VCA_CMD_SET_SCHEDULE_ENABLE_ID = 11;    // Set enable of VCA
            public int VCA_CMD_SET_RULE9_FACEREC_ID = 12;      // Set rule of VCA(face recognition)
            public int VCA_CMD_SET_RULE10_VIDEODETECT_ID = 13; // Set rule of VCA(video diagnose)
            public int VCA_CMD_SET_RULE8_ABANDUM_ID = 14;      // Set rule of VCA(abandon)
            public int VCA_CMD_SET_RULE7_OBJSTOLEN_ID = 15;    // Set rule of VCA(stolen)
            public int VCA_CMD_SET_RULE11_TRACK_ID = 16;       // Set rule of VCA(follow)

            public string VCA_CMD_SET_CHANNEL_DESC = "VCA Channel Number and Enable";
            public string VCA_CMD_SET_VIDEOSIZE_DESC = "VCA Channel of video size";
            public string VCA_CMD_SET_ADVANCE_PARAM_DESC = "VCA advanced parameter";
            public string VCA_CMD_SET_TARGET_PARAM_DESC = "VCA superimpose paramenter and colour setting";
            public string VCA_CMD_SET_ALARM_STATISTIC_DESC = "VCA alarm count is zero";
            public string VCA_CMD_SET_RULE_COMMON_DESC = "Rule of VCA convention parameter";
            public string VCA_CMD_SET_RULE0_TRIPWIRE_DESC = "Rule of VCA(single tripwire)";
            public string VCA_CMD_SET_RULE1_DBTRIPWIRE_DESC = "Rule of VCA(double tripwire)";
            public string VCA_CMD_SET_RULE2_PERIMETER_DESC = "Rule of VCA(perimeter)";
            public string VCA_CMD_SET_ALARM_SCHEDULE_DESC = "VCA alarm module";
            public string VCA_CMD_SET_ALARM_LINK_DESC = "VCA input port";
            public string VCA_CMD_SET_SCHEDULE_ENABLE_DESC = "enable of VCA";
            public string VCA_CMD_SET_RULE9_FACEREC_DESC = "Rule of VCA(face recognition)";
            public string VCA_CMD_SET_RULE10_VIDEODETECT_DESC = "Rule of VCA(video diagnose)";
            public string VCA_CMD_SET_RULE8_ABANDUM_DESC = "Rule of VCA(abandon)";
            public string VCA_CMD_SET_RULE7_OBJSTOLEN_DESC = "Rule of VCA(stolen)";
            public string VCA_CMD_SET_RULE11_TRACK_DESC = "Rule of VCA(follow)";

        
    }
}
