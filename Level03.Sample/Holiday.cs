using System;
using System.Collections.Generic;
using System.Text;

namespace Level03.Sample
{
    public class Holiday
    {
        public string IsTodayXmas()
        {
            var today = SystemTime.Today;

            if (today.Month == 12 && today.Day == 25)
            {
                return "Merry Xmas!!";
            }
            else
            {
                return "Today is not Xmas";
            }
        }
    }
}