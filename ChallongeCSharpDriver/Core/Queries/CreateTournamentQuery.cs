using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using ChallongeCSharpDriver.Core;
    using ChallongeCSharpDriver.Core.Results;

    public class CreateTournamentQuery : ChallongeQuery<TournamentResult> {
        public string name { get; set; }
        public TournamentType type { get; set; }
        public string url { get; set; }

        public DateTime? start_at { get; set; }
        public CreateTournamentQuery(string name, TournamentType type, string url) {
            this.name = name;
            this.type = type;
            this.url = url;
        }

        public CreateTournamentQuery(string name,DateTime? start_at, TournamentType type, string url)
        {
            this.name = name;
            this.type = type;
            this.url = url;
            this.start_at = start_at;
        }

        private class TournamentQueryResult {
            public TournamentResult tournament { get; set; }
        }

        private ChallongeQueryParameters getParameters() {
            ChallongeQueryParameters parameters = new ChallongeQueryParameters();
            parameters.Add("tournament[name]", name);
            parameters.Add("tournament[tournament_type]", TournamentTypeParser.ToCreateString(type));
            parameters.Add("tournament[url]", url);
            if(start_at.HasValue)
                parameters.Add("tournament[start_at]", start_at.Value.ToString("s"));
            return parameters;
        }

        private string getAPIPath() {
            return "tournaments";
        }

        public async Task<TournamentResult> call(ChallongeAPICaller caller) {
            TournamentQueryResult result = await caller.POST<TournamentQueryResult>(getAPIPath(), getParameters());
            return result.tournament;
        }
    }
}
