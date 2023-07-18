using AutoMapper;
using ClimateChangeEducation.Domain.DTOs;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClimateChangeEducation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }

        #region Course controller
        // GET: api/<CourseController>
        [HttpGet]
        [Route("GetCourses")]
        public async Task<IActionResult> GetCourses()
        {
            try
            {
                var courses = await _courseRepo.GetAllCoursesAsync();
                return (Ok(_mapper.Map<List<Course>>(courses)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CourseController>/5
        [HttpGet]
        [Route("GetCoursesById/{id}")]
        public async Task<IActionResult> GetCourseById([FromRoute]string id)
        {
            try
            {
                var result = await _courseRepo.GetCourseByIdAsync(id);
                return Ok(_mapper.Map<Course>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<CourseController>
        [HttpPost]
        [Route("CreateCourse")]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDTO request)
        {
            try
            {
                var course = await _courseRepo.CreateCourseAsync(_mapper.Map<Course>(request));
                return Ok(course);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<CourseController>/5
        [HttpPut]
        [Route("UpdateCourse/{id}")]
        public async Task<IActionResult> UpdateCourse([FromRoute] string id, [FromBody] CourseDTO request)
        {
            try
            {
                if (await _courseRepo.ExistsCourseAsync(id))
                {
                    // Update Details
                    var updatedCourse = await _courseRepo.UpdateCourseAsync(id, _mapper.Map<Course>(request));
                    if (updatedCourse != null)
                    {
                        return Ok(_mapper.Map<Student>(updatedCourse));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // DELETE api/<CourseController>/5
        [HttpDelete]
        [Route("DeleteCourse/{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] string id)
        {
            try
            {
                if (await _courseRepo.ExistsCourseAsync(id))
                {
                    var course = await _courseRepo.DeleteCourse(id);
                    return Ok(_mapper.Map<Course>(course));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        #endregion

        #region Course Module controller
        //---Module controller 


        [HttpGet]
        [Route("GetCourseModules")]
        public async Task<IActionResult> GetCourseModules()
        {
            try
            {
                var modules = await _courseRepo.GetAllCourseModulesAsync();
                return (Ok(_mapper.Map<List<CourseModule>>(modules)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CourseModuleController>/5
        [HttpGet]
        [Route("GetCourseModuleById/{id}")]
        public async Task<IActionResult> GetCourseModuleById([FromRoute] string id)
        {
            try
            {
                var result = await _courseRepo.GetCourseModuleByIdAsync(id);
                return Ok(_mapper.Map<CourseModule>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<CourseModuleController>
        [HttpPost]
        [Route("CreateCourseModule")]
        public async Task<IActionResult> CreateCourseModule([FromBody] CourseModuleDTO request)
        { 
            try
            {
               // var mm = new CourseModule();
               // mm.Course.CourseId = request.CourseId;
               // mm.ModuleDescription = request.ModuleDescription;
               // mm.ModuleName = request.ModuleName;
               //mm.MediaUrl = request.MediaUrl;
              
                var courseModule = await _courseRepo.CreateCourseModuleAsync(_mapper.Map<CourseModule>(request));
                //var courseModule = await _courseRepo.CreateCourseModuleAsync(request);
                return Ok(courseModule);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<CourseModuleController>/5
        [HttpPut]
        [Route("UpdateCourseModule")]
        public async Task<IActionResult> UpdateCourseModule([FromRoute] string id, [FromBody] CourseModuleDTO request)
        {
            try
            {
                if (await _courseRepo.ExistsCourseAsync(id))
                {
                    // Update Details
                    var updatedModule = await _courseRepo.UpdateCourseModuleAsync(id, _mapper.Map<CourseModule>(request));
                    if (updatedModule != null)
                    {
                        return Ok(_mapper.Map<CourseModule>(updatedModule));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // DELETE api/<CourseModuleController>/5
        [HttpDelete]
        [Route("DeleteCourseModule/{id}")]
        public async Task<IActionResult> DeleteCourseModule([FromRoute] string id)
        {
            try
            {
                if (await _courseRepo.ExistsCourseModuleAsync(id))
                {
                    var module = await _courseRepo.DeleteCourseModule(id);
                    return Ok(_mapper.Map<CourseModule>(module));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }
        #endregion

        #region Course Lesson controller 

        [HttpGet]
        [Route("GetCourseLessons")]
        public async Task<IActionResult> GetCourseLessons()
        {
            try
            {
                var lessons = await _courseRepo.GetAllCourseLessonsAsync();
                return (Ok(_mapper.Map<List<CourseLesson>>(lessons)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CourseLessonController>/5
        [HttpGet]
        [Route("GetCourseLessonById/{id}")]
        public async Task<IActionResult> GetCourseLessonById([FromRoute] string id)
        {
            try
            {
                var result = await _courseRepo.GetCourseLessonByIdAsync(id);
                return Ok(_mapper.Map<CourseLesson>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // POST api/<CourseLessonController>
        [HttpPost]
        [Route("CreateCourseLesson")]
        public async Task<IActionResult> CreateCourseLesson([FromBody] CourseLessonDTO request)
        {
            try
            {
                var courseLesson = await _courseRepo.CreateCourseLessonAsync(_mapper.Map<CourseLesson>(request));
                return Ok(courseLesson);
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // PUT api/<CourseLessonController>/5
        [HttpPut]
        [Route("UpdateLesson/{id}")]
        public async Task<IActionResult> UpdateCourseLesson([FromRoute] string id, [FromBody] CourseLessonDTO request)
        {
            try
            {
                if (await _courseRepo.ExistsCourseLessonAsync(id))
                {
                    // Update Details
                    var updatedLesson = await _courseRepo.UpdateCourseLessonAsync(id, _mapper.Map<CourseLesson>(request));
                    if (updatedLesson != null)
                    {
                        return Ok(_mapper.Map<CourseLesson>(updatedLesson));
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        // DELETE api/<CourseLessonController>/5
        [HttpDelete]
        [Route("DeleteLesson/{id}")]
        public async Task<IActionResult> DeleteCourseLesson([FromRoute] string id)
        {
            try
            {
                if (await _courseRepo.ExistsCourseLessonAsync(id))
                {
                    var lesson = await _courseRepo.DeleteCourseLesson(id);
                    return Ok(_mapper.Map<CourseLesson>(lesson));
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateLessonVideo/{id}")]
        public async Task<IActionResult> UpdateLessonVideo([FromRoute] string id, [FromBody] CourseLessonDTO request)
        {
            try
            {
                if (await _courseRepo.ExistsCourseLessonAsync(id))
                {    
                    // Update Details
                    var result = await _courseRepo.UpdateLessonVideoAsync(id, _mapper.Map<CourseLesson>(request.LessonVideoUrl).ToString());
                    if (result)
                    {
                        return Ok("Update Successful!");
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateLessonImage/{id}")]
        public async Task<IActionResult> UpdateLessonImage([FromRoute] string id, [FromBody] CourseLessonDTO request)
        {
            try
            {
                if (await _courseRepo.ExistsCourseLessonAsync(id))
                {
                    // Update Details
                    var result = await _courseRepo.UpdateLessonVideoAsync(id, _mapper.Map<CourseLesson>(request.LessonPhotoUrl).ToString());
                    if (result)
                    {
                        return Ok("Update Successful!");
                    }
                }
                return NotFound();
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }


        [HttpGet]
        [Route("GetLessonModuleById/{moduleId}")]
        public async Task<IActionResult> GetLessonModuleById([FromRoute] string moduleId)
        {
            try
            {
                var result = await _courseRepo.GetLessonByModuleIdAsync(moduleId);
              
                return Ok(_mapper.Map<CourseLesson>(result));
            }
            catch (ArgumentException argex)
            {
                return BadRequest(argex.Message);
            }
        }
        #endregion


    }
}
