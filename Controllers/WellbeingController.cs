using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class WellbeingController : ControllerBase
{
    
    private static List<UserInteractionData> userDataList = new List<UserInteractionData>();

    [HttpPost("process-emotion-data")]
    public IActionResult ProcessEmotionData([FromBody] UserInteractionData data)
    {
        if (data == null || data.ClicksPerSecond < 0 || data.MouseMovements < 0)
        {
            return BadRequest("Invalid input data.");
        }

        userDataList.Add(data); 
        var stressLevel = CalculateStress(data);
        return Ok(new { stressLevel });
    }

    private int CalculateStress(UserInteractionData data)
    {
        int stress = 0;

        if (data.ClicksPerSecond > 5)
        {
            stress += (data.ClicksPerSecond - 5) * 10; 
        }

        if (data.MouseMovements > 1000)
        {
            stress += (data.MouseMovements - 1000) / 100; 
        }

        return Math.Min(stress, 100);
    }
}

public class UserInteractionData
{
    public int ClicksPerSecond { get; set; }
    public int MouseMovements { get; set; }
}