using Microsoft.AspNetCore.Mvc;
using P_01.Models;
using System.Data;
using System.Data.SqlClient;

namespace P_01.Controllers
{
    public class bmsController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Kevil Gandhi\\Documents\\Inetrnal_P_01.mdf\";Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter adp = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult display()
        {
            con.Open();
        
            List<book> bookList = new List<book>();

            adp = new SqlDataAdapter("SELECT * FROM book ORDER BY Id",con);
            adp.Fill(ds);
            dt = ds.Tables[0];

            foreach(DataRow dr in dt.Rows)
            {
                bookList.Add(new book { 
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    title = dr["title"].ToString(),
                    price = Convert.ToSingle(dr["price"].ToString())
                });
            }
            return View(bookList);
        }

        [HttpGet]
        public IActionResult insert()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult insert(book b)
        {
            
            con.Open();
            
            cmd = new SqlCommand($"INSERT INTO book VALUES('{b.title}',{b.price})", con);

            int r = cmd.ExecuteNonQuery();

            if(r == 1)
            {
                return RedirectToAction("display");
            }
            return View();
        }

        [HttpGet]
        public IActionResult update(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult update(book b)
        {
            con.Open();
            cmd = new SqlCommand($"UPDATE book SET title = '{b.title}', price = {b.price} WHERE Id = {b.Id}", con);
            int r = cmd.ExecuteNonQuery();

            if(r >= 1)
            {
                return RedirectToAction("display");
            }
            return View();
        }

        public IActionResult delete(int id)
        {
            con.Open();
            cmd = new SqlCommand($"DELETE FROM book WHERE Id = {id}", con);
            int r = cmd.ExecuteNonQuery();

            if (r >= 1)
            {
                return RedirectToAction("display");
            }
            return View();
        }

        [HttpGet]
        public IActionResult search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult search(int id)
        {
            con.Open();

            adp = new SqlDataAdapter($"SELECT * FROM book WHERE Id = {id}", con);
            adp.Fill(ds);
            dt = ds.Tables[0];            

            List<book> bookList = new List<book>();

            foreach (DataRow dr in dt.Rows)
            {
                bookList.Add(new book
                {
                    Id = Convert.ToInt32(dr["Id"].ToString()),
                    title = dr["title"].ToString(),
                    price = Convert.ToSingle(dr["price"].ToString())
                });
            }

            return View(bookList);
        }
    }
}
