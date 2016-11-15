using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myChat.Models.DB;

namespace myChat.BL
{   //uygulama için iş mantıklarını sağlayan katman
    public class ChatProcess
    {
        chatDBEntities e = new chatDBEntities();
        //üyelik alındığında kullanıcı verı tabanına kaydedilir
        public string createUser(User user)
        {
            int kullaniciSayisi = ((from x in e.User
                              where x.username == user.username
                              select x).ToList<User>()).Count;
            if (kullaniciSayisi > 0)
            {
                return "var";
            }
            else
            {
                e.User.Add(user);
                e.SaveChanges();
                return "eklendi";
            }

        }

        //kullanıcı listesi döndürür
        public List<User> userListGetir()
        {
            List<User> userlistemiz = ((from x in e.User
                                        select x).ToList<User>());

            return userlistemiz;
        }

        //chat veritabanına eklendi
        public string grupchatKaydet(GroupChat chat)
        {
            chat.time = DateTime.Now;
            e.GroupChat.Add(chat);
            return "yorum eklendi";
        }

        //mevcut grupların listesini verir
        public List<Group> groupListGetir()
        {
            List<Group> grouplistemiz = ((from x in e.Group
                                          select x).ToList<Group>());

            return grouplistemiz;
        }

        //üyrlik kontrolü. varsa 1den büyük
        public int loginCheck(string username,string password)
        {
            int kullaniciSayisi = ((from x in e.User
                                    where x.username == username && x.password==password
                                    select x).ToList<User>()).Count;
            return kullaniciSayisi;

        }
        
    }
}