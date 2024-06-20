using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the https://github.com/github-cloudlabsuser-1997/Contact-Database-Application.gitIndex method here
            return View(userlist);
        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            var user = userlist.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
 
        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            return View();
        }
 
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
            try
            {
                // Add the new user to the list
                userlist.Add(user);

                // Redirect to the Index view
                return RedirectToAction("Index");
            }
            catch
            {
                // If an error occurs, just return the same view to try again
                return View();
            }
        }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFound
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user to the Edit view
            return View(user);
        }
 
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            // Find the user in the list
            var userToUpdate = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFound
            if (userToUpdate == null)
            {
                return HttpNotFound();
            }

            try
            {
                // Update the user's information
                userToUpdate.Name = user.Name;
                userToUpdate.Email = user.Email;
                // Add any other fields you need to update

                // Redirect to the Index action to display the updated list of users
                return RedirectToAction("Index");
            }
            catch
            {
                // If an error occurs, return the Edit view to display any validation errors
                // Optionally, you can pass the user back to the view to repopulate the form
                return View(user);
            }
        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            // Find the user by ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFound
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user to the Delete view
            return View(user);
        }
 
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here
            // Find the user by ID
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFound
            if (user == null)
            {
                return HttpNotFound();
            }

            // Remove the user from the list
            userlist.Remove(user);

            // Redirect to the Index action to display the updated list of users
            return RedirectToAction("Index");
        }
    }
}
