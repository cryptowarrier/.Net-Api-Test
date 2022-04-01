using Newtonsoft.Json;
namespace ApiTest;

public class UserService
{
  public List<User>? users;
  public UserService()
  {
    string url = "https://gorest.co.in/public/v2/users";
    HttpClient client = new HttpClient();
    HttpResponseMessage response = client.GetAsync(url).Result;
    if(response.IsSuccessStatusCode)
    {
      users = JsonConvert.DeserializeObject<List<User>>(response.Content.ReadAsStringAsync().Result);
    }
  }

  public List<User> getActiveUsers()
  {
    List<User> activeUsers = new List<User>();
    users?.ForEach(user => {
      if(user.status == "active")
      {
        activeUsers.Add(user);
      }
    });
    return activeUsers;
  }
  public List<User> getInactiveFemales()
  {
    List<User> inactiveFemales = new List<User>();
    users?.ForEach(user => {
      if(user.status == "inactive" && user.gender == "female")
      {
        inactiveFemales.Add(user);
      }
    });
    return inactiveFemales;
  }
  public User getUserByEmail(string email)
  {
    User findUser = new User();
    users?.ForEach(user => {
      if(user.email == email) {
        findUser = user;
      }
    });
    return findUser;
  }
}
