using MonkeyHubApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyHubApp.Services
{
    public interface IMonkeyHubApiService
    {
        Task<List<Tag>> GetTagsAsync();
        Task<List<Content>> GetContentByTagIdAsync(string tagId);
        Task<List<Content>> GetContentByFilterAync(string filter);
     }
}
