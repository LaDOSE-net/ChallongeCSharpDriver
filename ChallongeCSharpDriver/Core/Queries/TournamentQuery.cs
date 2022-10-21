using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Queries {
    using ChallongeCSharpDriver.Core;
    using ChallongeCSharpDriver.Core.Results;

    public class TournamentQuery : ChallongeQuery<TournamentResult> {
        public string tournamentID { get; set; }
        //WTF IS THIS SHIT ? 
        public TournamentQuery(int tournamentID) {
            this.tournamentID = tournamentID.ToString();
        }
        public TournamentQuery(string tournamentUrl)
        {
            this.tournamentID = tournamentUrl;
        }

        private class TournamentQueryResult {
            public TournamentResult tournament { get; set; }
        }

        private ChallongeQueryParameters getParameters() {
            return new ChallongeQueryParameters();
        }

        
        private string getAPIPath() {
                return "tournaments/" + tournamentID;
        }

        public async Task<TournamentResult> call(ChallongeAPICaller caller) {
            TournamentQueryResult tournamentQueryResult = await caller.GET<TournamentQueryResult>(getAPIPath(), getParameters());
            return tournamentQueryResult.tournament;
        }
    }
}
