using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Final_LitchiLearn.Models;
using Final_LitchiLearn.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_LitchiLearn.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TeacherController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Subject()
        {           
            //load subjects to the Subject Page
            IEnumerable<Subject> sub = _db.Subjects;
            return View(sub);
        }
        public IActionResult Topics()
        {
            IEnumerable<Topics> topic = _db.Topics;
            return View(topic);
        }
        public IActionResult Quiz()
        {
            IEnumerable<Quiz> quiz = _db.Quizzes;
            return View(quiz);
        }
        public IActionResult Student()
        {
            return View();
        }
        public IActionResult QuizMarks()
        {
            return View();
        }
        public IActionResult Report()
        {
            return View();
        }
        public IActionResult TopicCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TopicCreate(Topics topic)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Topics.Add(topic);
                _db.SaveChanges();
                return RedirectToAction("Topics");
            }
            return View(topic);

        }

        public IActionResult SubjectCreate() //takes us to create subject page to add subject
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubjectCreate(Subject subject)
        {
            if (ModelState.IsValid)//Checks to see if all the required fields have been met.
            {
                _db.Subjects.Add(subject);
                _db.SaveChanges();
                return RedirectToAction("Subject");
            }
            return View(subject);

        }



        public IActionResult UpdateSubject(int? id)//Get subject we want to update
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Subjects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSubject(Subject sub) //post update to update the changes
        {

            _db.Subjects.Update(sub);
            _db.SaveChanges();
            return RedirectToAction("Subject");
        }
        public IActionResult UpdateTopic(int? id)//Get subject we want to update
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Topics.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTopic(Topics topic) //post update to update the changes
        {

            _db.Topics.Update(topic);
            _db.SaveChanges();
            return RedirectToAction("Topics");
        }
        public IActionResult CreateQuiz()
        {
            PopulateTopicDropDownList();
            return View();
        }
        private void PopulateTopicDropDownList(object selectedTopic = null)
        {
            var topicQuery = from t in _db.Topics
                             orderby t.TopicName
                             select t;
            ViewBag.TopicID = new SelectList(topicQuery.AsNoTracking(), "TopicID", "TopicName", selectedTopic);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateQuiz([Bind("QuizID,QuizName,TotalMarks,TopicID")] Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                _db.Add(quiz);
                await _db.SaveChangesAsync();
                return RedirectToAction("Quiz");
            }
            PopulateTopicDropDownList(quiz.TopicID);
            return View(quiz);
        }
        
        public IActionResult Questions()
        {
            IEnumerable<Question> quiz = _db.Questions;
            return View(quiz);
        }
        public IActionResult QuesCreate()
        {
            PopulateQuiz();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuesCreate([Bind("QuestionID,QuesDesc,Answer,Option1,Option2,Option3,Option4,QuizID")]Question ques)
        {
            if (ModelState.IsValid)
            {
                _db.Add(ques);
                await _db.SaveChangesAsync();
                return RedirectToAction("Question");
            }
            PopulateQuiz(ques.QuizID);
            return View(ques);

        }
        private void PopulateQuiz(object selectedQuiz = null)
        {
            var quizQuery = from q in _db.Quizzes
                             orderby q.QuizName
                             select q;
            ViewBag.QuizID = new SelectList(quizQuery.AsNoTracking(), "QuizID", "QuizName", selectedQuiz);
        }


    }

}
