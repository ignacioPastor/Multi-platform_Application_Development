
package unit1.leaguemanager.model;

/**
 * Final Exercise of Unit 1 - PSP
 * @author Ignacio Pastor Padilla
 * This class characterices the particularities of Matches
 * Implements Comparable, and receives a generic who inherit of Team
 * @param <T> FootballTeam or BasketballTeam
 */
public class Match<T extends Team> implements Comparable<Match<T>> {
    
    private T localTeam;
    private T visitorTeam;
    private int localScore;
    private int visitorScore;
    /**
     * void constructor
     */
    public Match(){
        
    }
    /**
     * constructor with parameters
     * @param localTeam
     * @param visitorTeam
     * @param localScore
     * @param visitorScore 
     */
    public Match(T localTeam, T visitorTeam, int localScore, int visitorScore){
        this.localTeam = localTeam;
        this.visitorTeam = visitorTeam;
        this.localScore = localScore;
        this.visitorScore = visitorScore;
    }
    /**
     * setter of localTime
     * @param localTeam 
     */
    public void setLocalTeam(T localTeam){
        this.localTeam = localTeam;
    }
    /**
     * getter of localTeam
     * @return localTeam
     */
    public T getLocalTeam(){
        return localTeam;
    }
    /**
     * setter of visitorTeam
     * @param visitorTeam 
     */
    public void setVisitorTeam(T visitorTeam){
        this.visitorTeam = visitorTeam;
    }
    /**
     * getter of visitorTeam
     * @return visitorTeam
     */
    public T getVisitorTeam(){
        return visitorTeam;
    }
    /**
     * setter of localScore
     * @param localScore 
     */
    public void setLocalScore(int localScore){
        this.localScore = localScore;
    }
    /**
     * getter of localScore
     * @return localScore
     */
    public int getLocalScore(){
        return localScore;
    }
    /**
     * setter of visitorScore
     * @param visitorScore 
     */
    public void setVisitorScore(int visitorScore){
        this.visitorScore = visitorScore;
    }
    /**
     * getter of visitorScore
     * @return visitorScore
     */
    public int getVisitorScore(){
        return visitorScore;
    }
    /**
     * Updates de data of each team involved in this match
     */
    public void updateTeamsData(){
        //Detect who wins or if its drawn, and update the number of matches won/lost/drawn
        if(localScore > visitorScore){ //local win, visitor loose
            localTeam.incMatchesWon();
            visitorTeam.incMatchesLost();
        }else if(visitorScore > localScore){ // local loose, visitor win
            visitorTeam.incMatchesWon();
            localTeam.incMatchesLost();
        }else{  //In basketball doesn't exists drawn, only footbal matches will be able to use this else
            try{
                ((FootballTeam)localTeam).incMatchesDrawn();
                ((FootballTeam)visitorTeam).incMatchesDrawn();
            }catch(Exception e){
                System.err.println("Error: There are no drawn in basketball.");
                System.err.println("Error message: " + e.getMessage());
            }
        }
        //Update data of goals/points
        if(localTeam instanceof FootballTeam){
            ((FootballTeam)localTeam).setGoals(((FootballTeam)localTeam).getGoals() + localScore);
            ((FootballTeam)localTeam).setGoalsAgainst(((FootballTeam)localTeam).getGoalsAgainst() + visitorScore);
            ((FootballTeam)visitorTeam).setGoals(((FootballTeam)visitorTeam).getGoals() + visitorScore);
            ((FootballTeam)visitorTeam).setGoalsAgainst(((FootballTeam)visitorTeam).getGoalsAgainst() + localScore);
        }else{  //BasketballTeam
            ((BasketballTeam)localTeam).setPointsFor(((BasketballTeam)localTeam).getPointsFor() + localScore);
            ((BasketballTeam)localTeam).setPointsAgainst(((BasketballTeam)localTeam).getPointsAgainst() + visitorScore);
            ((BasketballTeam)visitorTeam).setPointsFor(((BasketballTeam)visitorTeam).getPointsFor() + visitorScore);
            ((BasketballTeam)visitorTeam).setPointsAgainst(((BasketballTeam)visitorTeam).getPointsAgainst() + localScore);
        }
    }
    /**
     * Implements compareTo of Comparable.
     * The point of this method and this implementation is the correct detection by TreeSet of equal matches
     * We don't take care of any kind of sort for matches list
     * @param o match to compare with
     * @return 0 if both matches are the same, 1 if not
     */
    @Override
    public int compareTo(Match<T> o) {
        if(this.localTeam.getTeamCode().equals(o.localTeam.getTeamCode())
            && this.visitorTeam.getTeamCode().equals(o.visitorTeam.getTeamCode()))
            return 0;
        return 1;
        //return this.localTeam.getTeamName().compareTo(o.localTeam.getTeamName());
    }

    
    
    
}
