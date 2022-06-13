using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GlobalFunctions
{
  public enum UserLevels { Admin, Operator }
  public class User
  {

    private static List<User> _users;
    private static string _password = "ilkerp@SSwordilker";
    public string UserName { get; set; }

    public UserLevels UserLevel { get; set; }

    public string UserPassword { get; set; }

    /// <summary>
    /// Use for access selected user
    /// </summary>
    public static User ActiveUser { get; set; }

    public User(string userName, UserLevels userLevel, string userPassword)
    {
      UserName = userName;
      UserLevel = userLevel;
      UserPassword = userPassword;
      _users.Add(this);
    }

    static User()
    {
      _users = new List<User>();
    }

    public static void RemoveUser(User user)
    {
      _users.Remove(user);
    }

    public static void Clear()
    {
      _users.Clear();
    }


    private static Exception SaveSettingsAsXML(string fileName, List<UserSetting> userSettings)
    {
      FileStream fs = null;
      try
      {
        fs = new FileStream(fileName, FileMode.Create);
        XmlSerializer x = new XmlSerializer(typeof(List<UserSetting>));
        x.Serialize(fs, userSettings);

      }
      catch (Exception ex)
      {
        return ex;
      }
      finally
      {
        if (fs != null)
          fs.Close();
      }
      return null;
    }

    private static List<UserSetting> LoadSettingsFromXML(string fileName)
    {
      if (File.Exists(fileName))
      {
        try
        {
          using (StreamReader fs = new StreamReader(fileName))
          {
            XmlSerializer x = new XmlSerializer(typeof(List<UserSetting>));
            return (List<UserSetting>)x.Deserialize(fs);
          }
        }
        catch { }
      }
      return null;
    }

    public static void SaveUserListToFile(string fileName)
    {
      List<UserSetting> userSettings = new List<UserSetting>();
      foreach (User usr in _users)
      {
        UserSetting userSetting = new UserSetting();
        userSetting.Name = usr.UserName;
        userSetting.UserLevel = Sha256StringCrypter.Encrypt(usr.UserLevel.ToString(), _password);
        userSetting.Password = Sha256StringCrypter.Encrypt(usr.UserPassword, _password);
        userSettings.Add(userSetting);
      }
      SaveSettingsAsXML(fileName, userSettings);
    }



    public static void LoadUserListFromFile(string fileName)
    {
      List<UserSetting> userSettings = LoadSettingsFromXML(fileName);
      if (userSettings != null)
      {

        _users.Clear();
        foreach (UserSetting userSet in userSettings)
        {
          User user = new User(userSet.Name, (UserLevels)Enum.Parse(typeof(UserLevels), Sha256StringCrypter.Decrypt(userSet.UserLevel, _password)), Sha256StringCrypter.Decrypt(userSet.Password, _password));
        }
      }
    }

    public override string ToString()
    {
      return UserName;
    }

    public static List<User> GetUserList()
    {
      return _users.ToList();
    }
  }


}
