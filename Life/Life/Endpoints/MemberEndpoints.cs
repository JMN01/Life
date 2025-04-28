using Life.Data;
using Life.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Life.Controllers;

public static class MemberEndpoints
{
    public static RouteGroupBuilder MapEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/", async (DataContext context) => await context.Members
            .Include(m => m.Personal)
            .Include(m => m.Team)
            .ThenInclude(m => m.Location)
            .Include(m=>m.Workout)
            .ThenInclude(m=>m.WorkoutExercises)
            .ThenInclude(m => m.Exercise)
            .Include(m => m.Meal)
            .ThenInclude(m => m.Food)
            .ThenInclude(m => m.FoodNutrients)
            .ThenInclude(m => m.Nutrient)
            .ToListAsync());

        group.MapGet("/{id:int}", async (DataContext context, int id) =>
        {
            var result = await context.Members
                .Include(m => m.Personal)
                .Include(m => m.Team)
                .ThenInclude(t => t.Location)
                .Include(m => m.Workout)
                .ThenInclude(w => w.WorkoutExercises)
                .ThenInclude(wm => wm.Exercise)
                .Include(m => m.Meal)
                .ThenInclude(f => f.Food)
                .ThenInclude(fn => fn.FoodNutrients)
                .ThenInclude(n => n.Nutrient)
                .FirstOrDefaultAsync(member => member.MemberId == id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
            
        });

        group.MapPost("/", async (DataContext context, Member newMember) =>
        {
            if (newMember == null)
            {
                return Results.NotFound("Member not found!");
            }

            context.Add(newMember);
            await context.SaveChangesAsync();

            return Results.Created($"/api/members/{newMember.MemberId}", newMember);
        });

        group.MapPut("/{id:int}", async (DataContext context, int id, Member updateMember) =>
        {
            var _member = await context.Members
                .FindAsync(id);
            if (_member is null)
            {
                return Results.NotFound();
            }

            _member.Name = updateMember.Name;
            _member.IsActive = updateMember.IsActive;
            _member.LicenseNumber = updateMember.LicenseNumber;
            _member.RoleType = updateMember.RoleType;
            /*
            result.Personal = updateMember.Personal;
            result.Workout = updateMember.Workout;
            result.Meal = updateMember.Meal;
            result.Team = updateMember.Team;

            result.WorkoutId = updateMember.WorkoutId;
            result.MealId = updateMember.MealId;
            result.TeamId = updateMember.TeamId;
            result.PersonalId = updateMember.PersonalId;
*/          //context.Update(result);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (DataContext context, int id) =>
        {
            var result = await context.Members.FindAsync(id);
            if (result == null)
            {
                return Results.NotFound("Member not found!");
            }

            context.Remove(result);
            await context.SaveChangesAsync();

            return Results.NoContent();
        });
        
        return group;
    }
}