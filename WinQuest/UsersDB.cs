using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinQuest
{
    public class UsersDB : SQLite.SQLiteDataBase
    {
        public UsersDB(string FileName) : base(FileName)
        {
            if (File.Exists(FileName))
            {
                OpenDB();
            }
            else
            {
                CreateDB(@"CREATE TABLE 'users' (

    'id'    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    'user_name' TEXT,
    'phone' TEXT,
    'mail'  TEXT,
    'points'    INTEGER DEFAULT 0
); ");
            }
        }

        public void Update(string Column, string Value, long ID)
        {
            string NewValue = Value.Replace("'", "''");
            Execute($"UPDATE `users` SET `{Column}` = '{NewValue}' WHERE `id`={ID};'");
        }

        public List<User> GetUserList()
        {
            List<User> U = new List<User>();

            DataTable dt = ReadTable($"SELECT * FROM `users` ORDER BY `points` DESC");

            foreach (DataRow Row in dt.Rows)
            {
                U.Add(User.ReadUser( this,
                    Convert.ToInt64(Row.ItemArray[dt.Columns.IndexOf("id")]),
                    Row.ItemArray[dt.Columns.IndexOf("user_name")].ToString(),
                    Row.ItemArray[dt.Columns.IndexOf("phone")].ToString(),
                    Row.ItemArray[dt.Columns.IndexOf("mail")].ToString(),
                    Convert.ToInt32(Row.ItemArray[dt.Columns.IndexOf("points")])
                    ));
            }

            return U;
        }
    }

    public class User
    {
        private long ID;
        private string name;
        private string phone;
        private string mail;
        private int points;
        private UsersDB DB;

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;
                DB.Update("user_name", name, ID);
            }
        }

        /// <summary>
        /// Телефон пользователя
        /// </summary>
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                DB.Update("phone", phone, ID);
            }
        }

        /// <summary>
        /// Электрпонный адрес пользователя
        /// </summary>
        public string Mail
        {
            get => mail;
            set
            {
                mail = value;
                DB.Update("mail", mail, ID);
            }
        }
        public int Points
        {
            get => points;
            set
            {
                points = value;
                DB.Update("points", points.ToString(), ID);
            }
        }

        private User()
        {

        }

        public User(UsersDB db)
        {
            DB = db;
            DB.Execute($"INSERT INTO `users` (`user_name`) VALUES ('')");
            ID = db.LastID;
        }

        public User(UsersDB db, long id)
        {
            DB = db;
            ID = id;
            DataTable dt = DB.ReadTable($"SELECT * FROM `users` WHERE `id`={ID}");
            if (dt.Rows.Count == 0)
            {
                throw new Exception($"Отсутствует запись с ID={ID} в базе данных.");
            }

            name = dt.Rows[0].ItemArray[dt.Columns.IndexOf("user_name")].ToString();
            phone = dt.Rows[0].ItemArray[dt.Columns.IndexOf("phone")].ToString();
            mail = dt.Rows[0].ItemArray[dt.Columns.IndexOf("mail")].ToString();
            points = Convert.ToInt32(dt.Rows[0].ItemArray[dt.Columns.IndexOf("points")]);
        }

        public static User ReadUser(UsersDB db, long id, string name, 
            string phone, string mail, int points)
        {
            return new User()
            {
                DB = db,
                ID = id,
                name = name,
                phone = phone,
                mail = mail,
                points = points
            };
        }
    }
}
