
package unit1.leaguemanager.model;


/**
 * Final Exercise of Unit 1 - PSP
 * @author Ignacio Pastor Padilla
 * This class characterices the particularities of FootballTeam
 * Inherits from Team
 */
public class FootballTeam extends Team{

    private int matchesDrawn; //Number of matches Drawn (same goals eache team)
    private int goals; //Total of goals in this league
    private int goalsAgainst; //Total of goals received in this league
    /**
     * Void Constructor
     */
    public FootballTeam(){
        
    }
    /**
     * Constructor with parameters
     * @param teamCode
     * @param teamName 
     */
    public FootballTeam(String teamCode, String teamName){
        super(teamCode, teamName);
        matchesDrawn = 0;
        goals = 0;
        goalsAgainst = 0;
    }
    /**
     * setter of matchesDrawn
     * @param matchesDrawn 
     */
    public void setMatchesDrawn(int matchesDrawn){
        this.matchesDrawn = matchesDrawn;
    }
    /**
     * getter of matchesDrawn
     * @return matchesDrawn
     */
    public int getMatchesDrawn(){
        return matchesDrawn;
    }
    /**
     * setter of goals
     * @param goals 
     */
    public void setGoals(int goals){
        this.goals = goals;
    }
    /**
     * getter of goals
     * @return goals
     */
    public int getGoals(){
        return goals;
    }
    /**
     * setter of goalsAgainst
     * @param goalsAgainst 
     */
    public void setGoalsAgainst(int goalsAgainst){
        this.goalsAgainst = goalsAgainst;
    }
    /**
     * getter of goalsAgainst
     * @return goalsAgainst
     */
    public int getGoalsAgainst(){
        return goalsAgainst;
    }
    /**
     * Override getter of total matches played for consider the matchesDrawn
     * @return  matches playes (win, lost and drawn)
     */
    @Override
    public int getTotalPlayed(){
        return super.getTotalPlayed() + matchesDrawn;
    }
    /**
     * implements abstract method of father for get the total points 
     * @return total points
     */
    @Override
    public int getTotalPoints() {
        return 3 * matchesWon + matchesDrawn;
    }
    /**
     * implements abstract method of father for print the information of the FootballTeam
     */
    @Override
    public void print() {
        System.out.printf("%-5s%-30s%5d%5d%5d%5d%5d%5d%5d%n", teamCode, teamName, getTotalPlayed(), 
            matchesWon, matchesDrawn, matchesLost, goals, goalsAgainst, getTotalPoints());
    }
    /**
     * static method for print a header before print the table league
     */
    public static void printHeader(){
        System.out.printf("%-5s%-30s%5s%5s%5s%5s%5s%5s%5s%n", "", "", "Total", 
            "W", "D", "L", "GF", "GA", "Pts");
    }
    /**
     * increases by 1 the number of matchesDrawn
     */
    public void incMatchesDrawn(){
        matchesDrawn++;
    }
}
