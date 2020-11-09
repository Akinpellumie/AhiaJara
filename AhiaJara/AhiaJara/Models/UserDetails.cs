using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AhiaJara.Models
{
      // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class UserDetails
    {
        public string email { get; set; } 
        public string firstName { get; set; } 
        public string lastName { get; set; } 
        public string password { get; set; } 
        public string phoneNo { get; set; } 
    }


    public class ModifyPassword
    {
        public string email { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Profile
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string userImgUrl { get; set; }
        public bool isAdmin { get; set; }
        public string phoneNo { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool isVerified { get; set; }
        public string email { get; set; }

        public ImageSource UserImage
        {

            get
            {
                var source = new Uri(userImgUrl);
                //var source = new Uri("http://192.168.1.118:5000/images/uploaded_images/" + Image);

                return source;
            }
            set { UserImage = value; }
        }

    }

    public class UserProfile
    {
        public Profile profile { get; set; }
        public string token { get; set; }
        public int cartcount { get; set; }
    }


}


//public Users(string Username, string Password)
//{
//    this.Email = Email;
//    this.Password = Password;
//}

//public bool CheckInformation()
//{
//    if (!string.IsNullOrEmpty(this.Email) && !string.IsNullOrEmpty(this.Password))
//        return true;
//    else
//        return false;
//}

//public ImageSource UserImage
//{

//    get
//    {
//        //var source = new Uri(ConstantsValue.MainAddress + ConstantsValue.ImageUrl + Image);
//        var source = new Uri("http://192.168.1.118:5000/images/users_images/" + Image);

//        return source;
//    }
//    set { UserImage = value; }
//}

//public string name
//{
//    get
//    {
//        return this.FirstName + "  " + this.LastName;
//    }
//}

//public string capitalizedname
//{
//    get
//    {
//        return this.name.ToUpper();
//    }
//}