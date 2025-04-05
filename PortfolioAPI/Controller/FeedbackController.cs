using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Data;
using PortfolioAPI.Models;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FeedbackController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpPost]
    public async Task<IActionResult> SubmitFeedback([FromBody] Feedback feedback)
    {
        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Feedback saved!" });
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedback()
    {
        return await _context.Feedbacks.ToListAsync();
    }



    [HttpGet("countbyrating/{rating}")]
    public async Task<ActionResult<int>> GetFeedbackCountByRating(int rating)
    {
        var count = await _context.Feedbacks
        .Where(f => f.Response == rating)
        .CountAsync();

        return Ok(count);
    }

    
    

    [HttpDelete ("delete")]
    public async Task<IActionResult> DeleteAllFeedback()
    {
        var allFeedback = await _context.Feedbacks.ToListAsync();

        _context.Feedbacks.RemoveRange(allFeedback);
        await _context.SaveChangesAsync();

        return Ok("All feedback entries have been deleted.");
    }





}