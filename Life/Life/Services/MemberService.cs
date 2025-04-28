using Life.Data;
using Life.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Life.Services;

public class MemberService 
{
    private readonly DataContext _context;


    public MemberService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Member>> GetMembersWithDetails()
    {
        return await _context.Members
            .Include(m => m.Personal)
            .Include(m => m.Team)
                .ThenInclude(t => t.Location)
            .Include(m => m.Workout)
                .ThenInclude(w => w.WorkoutExercises)
                    .ThenInclude(w => w.Exercise)
            .Include(m => m.Meal)
                .ThenInclude(f => f.Food)
                    .ThenInclude(fn => fn.FoodNutrients)
                        .ThenInclude(n => n.Nutrient)
            .ToListAsync();
    }
}