
package unit1.leaguemanager.model;

/**
 * Final Exercise of Unit 1 - PSP
 * @author Ignacio Pastor Padilla
 * This class characterices the particularities of BasketballTeam
 * Inherits from Team
 */
public class BasketballTeam extends Team{

    private int pointsFor; //Number of points done in this league (each goal gives 2 or 3 points)
    private int pointsAgainst; //Points against
    /**
     * void constructor
     */
    public BasketballTeam(){
        
    }
    /**
     * constructor with parameters
     * @param teamCode
     * @param teamName 
     */
    public BasketballTeam(String teamCode, String teamName){
        super(teamCode, teamName);
        pointsFor = 0;
        pointsAgainst = 0;
    }
    /**
     * setter of pointsFor
     * @param pointsFor 
     */
    public void setPointsFor(int pointsFor){
        this.pointsFor = pointsFor;
    }
    /**
     * getter of pointsFor
     * @return pointsFor
     */
    public int getPointsFor(){
        return pointsFor;
    }
    /**
     * setter of pointsAgainst
     * @param pointsAgainst 
     */
    public void setPointsAgainst(int pointsAgainst){
        this.pointsAgainst = pointsAgainst;
    }
    /**
     * getter of pointsAgainst
     * @return pointsAgainst
     */
    public int getPointsAgainst(){
        return pointsAgainst;
    }
    /**
     * Override abstract method of father 
     * @return total of points, (each match won give 2 points)
     */
    @Override
    public int getTotalPoints() {
        return 2 * matchesWon;
    }
    /**
     * Override abstract method of father for print the particular dades of BasketballTeam
     */
    @Override
    public void print() {
        System.out.printf("%-5s%-30s%5d%5d%5d%5d%5d%5d%n", teamCode, teamName, getTotalPlayed(), 
            matchesWon, matchesLost, pointsFor, pointsAgainst, getTotalPoints());
    }
    /**
     * static method for print the header in the league table
     */
    public static void printHeader(){
        System.out.printf("%-5s%-30s%5s%5s%5s%5s%5s%5s%n", "", "", "Total", 
            "W", "L", "GF", "GA", "Pts");
    }
    
}
