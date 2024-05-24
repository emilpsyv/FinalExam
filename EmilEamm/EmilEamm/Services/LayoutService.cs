using EmilEamm.DAL;
using Microsoft.EntityFrameworkCore;

namespace EmilEamm.Services
{
    public class LayoutService(ExamContext _context)
    {
        public async Task<Dictionary<string, string>> GetSettingsAsync()
        {
            Dictionary<string, string> settings = await _context.Setting.ToDictionaryAsync(s => s.Key, s => s.Value);

            return settings;

        }
    }
}
