
package unit1.leaguemanager.utils;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.util.ArrayList;
import java.util.List;
import unit1.leaguemanager.model.BasketballTeam;
import unit1.leaguemanager.model.FootballTeam;
import unit1.leaguemanager.model.Match;
import unit1.leaguemanager.model.Team;

/**
 * Final Exercise of Unit 1 - PSP
 * @author Ignacio Pastor Padilla
 * This class manage the principal structure of loading and saving data from files
 * The most of the method are static, methods of class, the objective of this
 * class is not been instantiated
 */
public class FileUtils {
    // Name of files where save/load data
    private static final String FOOTBALL_TEAMS_LIST_FILE = "football.txt";
    private static final String FOOTBALL_TEAMS_STATS_FILE = "football_stats.txt";
    private static final String BASKETBALL_TEAMS_LIST_FILE = "basketball.txt";
    private static final String BASKETBALL_TEAMS_STATS_FILE = "basketball_stats.txt";
    /**
     * void constructor
     */
    public FileUtils(){
        
    }
    /**
     * static method for load the list of footballTeams.
     * @return a list of FootballTeams
     */
    public static List<FootballTeam> loadFootballTeams(){
        List<FootballTeam>  lFootballTeams = new ArrayList<>();
        if(!(new File(FOOTBALL_TEAMS_LIST_FILE).exists())){ //Comprobe that de file exists
            System.err.println("File with football teams doesn't find");
        }else{
            BufferedReader fileFootballTeams;
            try{ //Read data of file
                fileFootballTeams = new BufferedReader(new FileReader(new File(FOOTBALL_TEAMS_LIST_FILE)));
                String line;
                String[] splitLine;
                while((line = fileFootballTeams.readLine())!= null){
                    splitLine = line.split(";");//we read a line with teamCode;teamName, we need to split by ";"
                    lFootballTeams.add(new FootballTeam(splitLine[0], splitLine[1])); //Create a new FootballTeam and add it to the list
                }
                fileFootballTeams.close();
            }catch(Exception e){
                System.err.println("There are an error: " + e.getMessage());
            }
        }
        return lFootballTeams;
    }
    /**
     * static method for load a basketballteams list from file
     * @return list of BasketballTeam
     */
    public static List<BasketballTeam> loadBasketballTeams(){
        List<BasketballTeam>  lBasketballTeams = new ArrayList<>();
        if(!(new File(BASKETBALL_TEAMS_LIST_FILE).exists())){ //Comprobe that file exists
            System.err.println("File with basketball teams doesn't find");
        }else{
            BufferedReader fileBasketballTeams;
            try{ //Reading...
            fileBasketballTeams = new BufferedReader(new FileReader(new File(BASKETBALL_TEAMS_LIST_FILE)));
            String line;
            String[] splitLine;
            while((line = fileBasketballTeams.readLine()) != null){
                splitLine = line.split(";"); //Separate data (in file appears teamCode;teamName)
                lBasketballTeams.add(new BasketballTeam(splitLine[0], splitLine[1])); //Create and store new BasketballTeam
            }
            fileBasketballTeams.close();
            }catch(Exception e){
                System.err.println("There are an error: " + e.getMessage());
            }
        }
        
        return lBasketballTeams;
    }
    /**
     * Load list of matches from a file
     * @param teamList list of footballTeams
     * @return list of football matches
     */
    public static List<Match<FootballTeam>> loadFootballMatches(List<FootballTeam> teamList){
        List<Match<FootballTeam>> lMatchFootball = new ArrayList<>();
        if(!(new File(FOOTBALL_TEAMS_STATS_FILE).exists())){ //Comprobe that file exists
            System.err.println("File with football matches hasn't been found");
        }else{
            BufferedReader fileFootballMatch;
            try{//Reading...
                fileFootballMatch = new BufferedReader(new FileReader(new File(FOOTBALL_TEAMS_STATS_FILE)));
                String linea;
                String[] splitLinea;
                Match<FootballTeam> m;
                while((linea = fileFootballMatch.readLine()) != null){
                    splitLinea = linea.split(" "); //Matches came in diferent lines, with dades separate by spaces
                    //We get teamCode from file, with that code look for that team in the teamList, and get that objetc Team
                    //Then, we create the new match
                    m = new Match(findTeamFootballByCode(splitLinea[0], teamList), findTeamFootballByCode(splitLinea[2], teamList),
                        Integer.parseInt(splitLinea[1]), Integer.parseInt(splitLinea[3]));
                    m.updateTeamsData(); //For each match, updateData for mantein synchronized the table league
                    lMatchFootball.add(m); //Finally, we add the match at the list of matchs
                }
                fileFootballMatch.close();
            }catch(Exception e){
                System.err.println("Error has ocurred: " + e.getMessage());
            }
        }
        return lMatchFootball;
    }
    /**
     * Look for a FootballTeam given his teamCode
     * @param code teamCode
     * @param teamList listFootballTeams
     * @return FootballTeam identified by given code
     */
    public static FootballTeam findTeamFootballByCode(String code, List<FootballTeam> teamList){
        FootballTeam fT = null;
        for (FootballTeam team : teamList) {
            if(team.getTeamCode().equalsIgnoreCase(code))
                fT = team;
        }
        if(!(fT != null)) //If we don't find any team with the given code, fT remains null. We send a message saying that Team not exist
            System.err.println("Unregistered team.");
        return fT;
    }
    /**
     * Load list of matches from a file
     * @param teamList list of BasketballTeams
     * @return list of basketball matches
     */
    public static List<Match<BasketballTeam>> loadBasketballMatches(List<BasketballTeam> teamList){
        //Same procedure that loadFootballMatches
        List<Match<BasketballTeam>> lMatchBasketball = new ArrayList<>();
        if(!(new File(BASKETBALL_TEAMS_STATS_FILE).exists())){
            System.err.println("File with basketball matches hasn't been found");
        }else{
            BufferedReader fileBasketballMatch;
            try{
                fileBasketballMatch = new BufferedReader(new FileReader(new File(BASKETBALL_TEAMS_STATS_FILE)));
                String linea;
                String[] splitLinea;
                Match<BasketballTeam> m;
                while((linea = fileBasketballMatch.readLine()) != null){
                    splitLinea = linea.split(" ");
                    m = new Match(findTeamBasketballByCode(splitLinea[0], teamList), findTeamBasketballByCode(splitLinea[2], teamList),
                        Integer.parseInt(splitLinea[1]), Integer.parseInt(splitLinea[3]));
                    m.updateTeamsData();
                    lMatchBasketball.add(m);
                }
                fileBasketballMatch.close();
            }catch(Exception e){
                System.err.println("Error has ocurred: " + e.getMessage());
            }
        }
        return lMatchBasketball;
    }
    /**
     * Look for a BasketballTeam given his teamCode
     * @param code teamCode
     * @param teamList listBasketballTeams
     * @return BasketballTeam identified by given code
     */
    public static BasketballTeam findTeamBasketballByCode(String code, List<BasketballTeam> teamList){
        BasketballTeam fT = null;
        for (BasketballTeam team : teamList) {
            if(team.getTeamCode().equalsIgnoreCase(code))
                fT = team;
        }
        if(!(fT != null))
            System.err.println("Unregistered team.");
        return fT;
    }
    /**
     * Save the list of football matches in txt file
     * User can add new matches, so this list can change, we need save the new information
     * @param listFootballMatches 
     */
    public static void saveFootballMatches(List<Match<FootballTeam>> listFootballMatches){
        BufferedWriter fileSaveFootballMatches;
        try{
            fileSaveFootballMatches = new BufferedWriter(new FileWriter(new File(FOOTBALL_TEAMS_STATS_FILE)));
            for(Match m : listFootballMatches){
                //Save each data of each match in the correct way, we will load this file in the future
                fileSaveFootballMatches.write(m.getLocalTeam().getTeamCode() + " " + m.getLocalScore()
                    + " " + m.getVisitorTeam().getTeamCode() + " " + m.getVisitorScore());
                fileSaveFootballMatches.newLine();
            }
            fileSaveFootballMatches.close();
        }catch(Exception e){
            System.err.println("Error: " + e.getMessage());
        }
    }
    /**
     * Save the list of basketball matches in txt file
     * User can add new matches, so this list can change, we need save the new information
     * @param listBasketballMatches 
     */
    public static void saveBasketballMatches(List<Match<BasketballTeam>> listBasketballMatches){
        BufferedWriter fileSaveBasketballMatches;
        try{
            fileSaveBasketballMatches = new BufferedWriter(new FileWriter(new File(BASKETBALL_TEAMS_STATS_FILE)));
            for(Match m : listBasketballMatches){
                fileSaveBasketballMatches.write(m.getLocalTeam().getTeamCode() + " " + m.getLocalScore()
                    + " " + m.getVisitorTeam().getTeamCode() + " " + m.getVisitorScore());
                fileSaveBasketballMatches.newLine();
            }
            fileSaveBasketballMatches.close();
        }catch(Exception e){
            System.err.println("Error: " + e.getMessage());
        }
    }
    /**
     * Save list of Matches, works with footballTeams and basketballTeams.
     * It would economice code, but the papers said two method, one for each kind of list
     * @param listMatches 
     */
    public static void saveMatches(List<Match<Team>> listMatches){
        BufferedWriter fileSaveMatches;
        String fileName = listMatches.get(0).getLocalTeam() instanceof FootballTeam 
                ? FOOTBALL_TEAMS_STATS_FILE : BASKETBALL_TEAMS_STATS_FILE;
        try{
            fileSaveMatches = new BufferedWriter(new FileWriter(new File(fileName)));
            for(Match m : listMatches){
                fileSaveMatches.write(m.getLocalTeam().getTeamCode() + " " + m.getLocalScore()
                    + " " + m.getVisitorTeam().getTeamCode() + " " + m.getVisitorScore());
                fileSaveMatches.newLine();
            }
            fileSaveMatches.close();
        }catch(Exception e){
            System.err.println("Error: " + e.getMessage());
        }
    }
}
