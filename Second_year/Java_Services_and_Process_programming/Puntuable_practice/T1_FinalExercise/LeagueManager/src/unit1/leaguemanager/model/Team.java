
package unit1.leaguemanager.model;


/**
 * Final Exercise Unit 1 - PSP
 * @author Ignacio Pastor Padilla
 * This class characterice common atrributes of each kind of teams
 */

public abstract class Team{

    protected String teamCode; //Each team have an unique code
    protected String teamName;
    protected int matchesWon; //Number of matches won in this league
    protected int matchesLost; // Matches lost in this league
    
    /**
     * Void constructor
     */
    public Team(){
        
    }
    /**
     * Constructor with parameters
     * @param teamCode code of team
     * @param teamName 
     */
    public Team(String teamCode, String teamName){
        this.teamCode = teamCode;
        this.teamName = teamName;
        matchesWon = 0;
        matchesLost = 0;
    }
    /**
     * setter of teamCode
     * @param teamCode 
     */
    public void setTeamCode(String teamCode){
        this.teamCode = teamCode;
    }
    /**
     * getter of teamCode
     * @return teamCode
     */
    public String getTeamCode(){
        return teamCode;
    }
    /**
     * setter of teamName
     * @param teamName 
     */
    public void setTeamName(String teamName){
        this.teamName = teamName;
    }
    /**
     * getter of teamName
     * @return teamName
     */
    public String getTeamName(){
        return teamName;
    }
    /**
     * setter of matchesWon
     * @param matchesWon 
     */
    public void setMatchesWon(int matchesWon){
        this.matchesWon = matchesWon;
    }
    /**
     * getter of matchesWon
     * @return matchesWon
     */
    public int getMatchesWon(){
        return matchesWon;
    }
    /**
     * setter of matchesLost
     * @param matchesLost 
     */
    public void setMatchesLost(int matchesLost){
        this.matchesLost = matchesLost;
    }
    /**
     * getter of matchesLost
     * @return matchesLost
     */
    public int getMatchesLost(){
        return matchesLost;
    }
    /**
     * Calculate the total of matches played in this league by this team
     * @return number of matches played
     */
    public int getTotalPlayed(){
        return matchesWon + matchesLost;
    }
    /**
     * @return return the total number of points won by the team. It will depend
     * of the team type, since points are calculated differently in football and basketball
     */
    public abstract int getTotalPoints();
    /**
     * will print a line with the team information
     */
    public abstract void print();
    
    /**
     * Increments by 1 the number of matches won
     */
    public void incMatchesWon(){
        matchesWon++;
    }
    /**
     * Increments by 1 the number of matches lost
     */
    public void incMatchesLost(){
        matchesLost++;
    }
    
    
}
