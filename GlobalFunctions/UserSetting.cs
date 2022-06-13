using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalFunctions
{
  [Serializable]
  public class UserSetting
  {
    public string Name { get; set; }

    public string Password { get; set; }

    public string UserLevel { get; set; }
  }
}
