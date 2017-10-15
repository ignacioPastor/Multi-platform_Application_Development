
package unit1.leaguemanager;

import java.util.List;
import java.util.Scanner;
import java.util.Set;
import java.util.StringJoiner;
import java.util.TreeSet;
import java.util.function.BiFunction;
import java.util.function.Predicate;
import java.util.stream.Collectors;
import unit1.leaguemanager.model.BasketballTeam;
import unit1.leaguemanager.model.FootballTeam;
import unit1.leaguemanager.model.Match;
import unit1.leaguemanager.model.Team;
import unit1.leaguemanager.utils.FileUtils;

/**
 * Final Exercise of Unit 1 - PSP
 * @author Ignacio Pastor Padilla
 * Main class. Manage the body of the program. A menu with diferents options.
 */
public class LeagueManager {
    // Lists of teams and matches, they are static list, of the class. It would simplify our code
    private static List<FootballTeam> listTeamsFootball;
    private static List<BasketballTeam> listTeamsBasketball;
    private static List<Match<FootballTeam>> listFootballMatches;
    private static List<Match<BasketballTeam>> listBasketballMatches;
    public static void main(String[] args) {
        //Load the list of teams
        try{listTeamsFootball  = FileUtils.loadFootballTeams();
        }catch(Exception e){
            System.err.println("Error loading listTeamsFootball: " + e.getMessage());
            listTeamsFootball = null;}
        try{listTeamsBasketball = FileUtils.loadBasketballTeams();
        }catch(Exception e){
            System.err.println("Error loading listTeamsBasketball: " + e.getMessage());
            listTeamsBasketball = null;}
        //Load the list of matches
        try{listFootballMatches = FileUtils.loadFootballMatches(listTeamsFootball);
        }catch(Exception e){
            System.err.println("Error loading listFootballMatches: " + e.getMessage());
            listFootballMatches = null;}
        try{listBasketballMatches = FileUtils.loadBasketballMatches(listTeamsBasketball);
        }catch(Exception e){
            System.err.println("Error loading listBasketballMatches: " + e.getMessage());
            listBasketballMatches = null;}
        //Sort the team lists
        listTeamsFootball.sort((FootballTeam f1, FootballTeam f2) -> f2.getTotalPoints() - f1.getTotalPoints());
        listTeamsBasketball.sort((BasketballTeam f1, BasketballTeam f2) -> f2.getTotalPoints() - f1.getTotalPoints());
        
        Scanner scanner = new Scanner(System.in);
        boolean exit;
        do{
            exit = false;
            showMenu(); // show Menu to user
            switch(scanner.nextLine()){ //We read the answer of the user
                case "1": //Show footbal league table
                    printFootballList(listTeamsFootball);
                    break;
                case "2": //Show basketball league table
                    printBasketballList(listTeamsBasketball);
                    break;
                case "3": //Add new football result
                    askMatch(3);
                    break;
                case "4": //Add new basketball result
                    askMatch(4);
                    break;
                case "5": //Show teams with more goals for than against in football league
                    printFootballList(listTeamsFootball.stream()
                        .filter(p -> (p.getGoals() - p.getGoalsAgainst()) > 0)
                        .collect(Collectors.toList()));
                    break;
                case "6": //Show scored points average in basketball league
                    System.out.printf("%nAverage points of basketball league: %.2f%n%n",
                        listTeamsBasketball.stream().mapToDouble(p -> p.getPointsFor()).average().orElse(0));
                    break;
                case "7": //Show points difference in football league
                    //We will use a BiFunction
                    BiFunction<FootballTeam,FootballTeam, Integer> pointsDiference 
                        = (f1,f2) -> f1.getTotalPoints() - f2.getTotalPoints();
                    System.out.printf("%nDiference between first and last Football teams: %d%n%n",
                        pointsDiference.apply(listTeamsFootball.get(0),
                        listTeamsFootball.get(listTeamsFootball.size() - 1)));
                    break;
                case "8": //Show teams that will go down to 2nd division
                    showTeams2Division();
                    break;
                case "9": //Show teams results
                    showResults();
                    break;
                case "0": //Exit
                    try{FileUtils.saveFootballMatches(listFootballMatches);
                    }catch(Exception e){
                        System.err.println("Error saving listFootballMatches: " + e.getMessage());
                    }
                    try{FileUtils.saveBasketballMatches(listBasketballMatches);
                    }catch(Exception e){
                        System.err.println("Error saving listBasketballMatches" + e.getMessage());
                    }
                    scanner.close();
                    exit = true;
                    break;
                default:
                    System.err.println("Error: that is not an available option.");
                    break;
            }
        }while(!exit);
    }
    /**
     * Show menu of available options for users
     */
    private static void showMenu(){
        System.out.println("1. Show football league table");
        System.out.println("2. Show basketball league table");
        System.out.println("3. Add new football result");
        System.out.println("4. Add new basketball result");
        System.out.println("5. Show teams with more goals for than against for football league");
        System.out.println("6. Show scored points average for basketball league");
        System.out.println("7. Show points difference in football league");
        System.out.println("8. Show teams that will go down to 2nd division");
        System.out.println("9. Show team results");
        System.out.println("0. Exit");
    }
    /**
     * prints football team lists, with his header
     * @param l listTeamsFootball
     */
    private static void printFootballList(List<FootballTeam> l){
        if(l == null)
            return;
        System.out.println();
        FootballTeam.printHeader(); //We use a static method of FootballTeamm class
        l.forEach(Team::print);
        System.out.println();
    }
    /**
     * Print basketball team lists, with his header
     * @param l listTeamsBasketball
     */
    private static void printBasketballList(List<BasketballTeam> l){
        if(l == null)
            return;
        System.out.println();
        BasketballTeam.printHeader(); //We use a static method of BasketballTeamm class
        l.forEach(Team::print);
        System.out.println();
    }
    /**
     * Manage the procedure for add new match
     * @param key indicates if come from option 3 or 4, if we deal with football team or basketball team
     */
    private static void askMatch(int key){
        Scanner scanner2 = new Scanner(System.in);
        System.out.println("Enter the result in the following format:");
        System.out.println("LOCAL_CODE LOCAL_SCORE VISITOR_CODE VISITOR_SCORE");
        System.out.println("Example:");
        System.out.println("ABC 3 DEF 1");
        String[] answer = scanner2.nextLine().split(" ");
        if(checkFormat(answer)){ // First, check the common characteristics of format
            if(key == 3){//key = 3 means we are managing a footballTeam (we ccme from option 3)
                //Check that teamCode indicate by user exists in out list
                if(checkFootballTeamExist(answer[0]) && checkFootballTeamExist(answer[2])){
                    //Create new match, getting the team thanks to the teamCode
                    Match<FootballTeam> m = new Match<>(FileUtils.findTeamFootballByCode(answer[0], listTeamsFootball),
                        FileUtils.findTeamFootballByCode(answer[2], listTeamsFootball),
                        Integer.parseInt(answer[1]), Integer.parseInt(answer[3]));
                    checkFootballDuplicates(m);//Check that the new match not already exist (same local team, with same visitor team)
                }else
                    System.err.println("Team code not registered.");
            }else{
                if(checkBastketballTeamExist(answer[0]) && checkBastketballTeamExist(answer[2])){
                    Match<BasketballTeam> m = new Match<>(FileUtils.findTeamBasketballByCode(answer[0], listTeamsBasketball),
                        FileUtils.findTeamBasketballByCode(answer[2], listTeamsBasketball),
                        Integer.parseInt(answer[1]), Integer.parseInt(answer[3]));
                    checkBasketballDuplicates(m);
                    
                }else
                    System.err.println("Team code not registered.");
            }
        }
    }
    /**
     * Manage the checking for common characteristics of football and basket matches
     * The point of this method is give an particular error messager, for each problem of validation
     * @param s user answer, separate in array by spaces
     * @return true if not error detected
     */
    private static boolean checkFormat( String[] s){
        // User introduces four units of data
        if(s.length != 4){
            System.err.println("Error: incorrect format");
            return false;
        }
        //Team code is 3 characters long
        if(s[0].length() != 3 ||s[2].length() != 3){
            System.err.println("Error: Team code must be 3 characters long");
            return false;
        }
        //Team code must be introduced in capital letters
        if(!s[0].equals(s[0].toUpperCase())||!s[2].equals(s[2].toUpperCase())){
            System.err.println("Team code must be in Capital Letters");
            return false;
        }
        //Team code must be compounded by letters
        if(s[0].matches("[^A-Z]")||s[2].matches("[^A-Z]")){
            System.err.println("Error: Team code must be compound by letters");
            return false;
        }
        //Goals/points of each team must be number
        if(s[1].matches("[^0-9]") || s[3].matches("[^0-9]")){
            System.err.println("Error: incorrect puntuation format");
            return false;
        }
        return true;
    }
    /**
     * Check that the code given by user exists in out list of teams
     * @param code teamCode
     * @return true if code given exists in out list
     */
    private static boolean checkFootballTeamExist(String code){
        for (int i = 0; i < listTeamsFootball.size(); i++)
            if(listTeamsFootball.get(i).getTeamCode().equals(code))
                return true;
        return false;
    }
    /**
     * Check that the code given by user exists in out list of teams
     * @param code teamCode
     * @return true if code given exists in out list
     */
    private static boolean checkBastketballTeamExist(String code){
        for (int i = 0; i < listTeamsBasketball.size(); i++)
            if(listTeamsBasketball.get(i).getTeamCode().equals(code))
                return true;
        return false;
    }
    /**
     * Check if match add by the user is duplicated (same localteam and same visitorTeam)
     * @param m match introduced by user
     */
    public static void checkFootballDuplicates(Match<FootballTeam> m){
        Set <Match<FootballTeam>> footballTreeSet = new TreeSet<>(); //Create new TreeSet
        listFootballMatches.add(m); //add new match at list of matches
        footballTreeSet.addAll(listFootballMatches); //add full list of matches at TreeSet, it will delete duplicates
        if(footballTreeSet.size() != listFootballMatches.size()){ //If there are duplicate, we'll found diferent sizes
            System.err.println("This match has already exist.");
            listFootballMatches.remove(m); //remove the match introduced (if we use TreeSet for remove we cuoul lose the original match)
        }else{//If new match is correct
            m.updateTeamsData();//sychronize the data
            //Sort listTeams, maybe the positions in the league has been change
            listTeamsFootball.sort((FootballTeam f1, FootballTeam f2) -> f2.getTotalPoints() - f1.getTotalPoints());
        }
        footballTreeSet.clear();
    }
    /**
     * Check if match add by the user is duplicated (same localTeam and same visitorTeam)
     * @param m match introduced by user
     */
    public static void checkBasketballDuplicates(Match<BasketballTeam> m){ //Same functionality than footbalTeam checking
        Set <Match<BasketballTeam>> basketballTreeSet = new TreeSet<>();
        listBasketballMatches.add(m);
        basketballTreeSet.addAll(listBasketballMatches);
        if(basketballTreeSet.size() != listBasketballMatches.size()){
            System.err.println("This match has already exist.");
            listBasketballMatches.remove(m);
        }else{
            m.updateTeamsData();
            listTeamsBasketball.sort((BasketballTeam b1, BasketballTeam b2) -> b2.getTotalPoints() - b1.getTotalPoints());
        }
        basketballTreeSet.clear();
    }
    /**
     * Print teams in 3 last positions of the football league
     */
    private static void showTeams2Division(){
        StringJoiner sJoinerFootball = new StringJoiner(", ");
        //We make subList with that three teams (list is ordered, so we take three las positions of the ArrayList)
        listTeamsFootball.subList(listTeamsFootball.size()-3, listTeamsFootball.size())
            .stream().map((p -> p.getTeamName())).forEach(p -> sJoinerFootball.add(p)); //make stream of that subList, map, and add to StringJoiner
        StringJoiner sJoinerBasketball = new StringJoiner(", ");//Same procedure for basketball league
        listTeamsBasketball.subList(listTeamsBasketball.size()-3, listTeamsBasketball.size())
            .stream().map((p -> p.getTeamName())).forEach(p -> sJoinerBasketball.add(p));
        //Print results
        System.out.println();
        System.out.println("FOOTBALL:");
        System.out.println(sJoinerFootball);
        System.out.println("BASKETBALL:");
        System.out.println(sJoinerBasketball);
    }
    /**
     * Print results of each match played by indicated team
     */
    private static void showResults(){
        String optionLeague;
        String code;
        Scanner scanner = new Scanner(System.in);
        System.out.println("Select league (1 - Football, 2 - Basketball):");
        optionLeague = scanner.nextLine(); // User select the league
        if(!(optionLeague.equals("1") || optionLeague.equals("2"))){
            System.err.println("It's not a valid option.");
            return;
        }
        System.out.println("Enter team code:");
        code = scanner.nextLine(); // User select the team which want to see
        if(optionLeague.equals("1")) //Print results, diferent ways for each league
            showFootballResults(code);
        else
            showBasketballResults(code);
        System.out.println();
    }
    /**
     * Print matches results of footballTeam
     * @param code teamCode
     */
    private static void showFootballResults(String code){
        FootballTeam t = FileUtils.findTeamFootballByCode(code, listTeamsFootball); //Take the team
        if(t == null)
            return;
        //Predicate for take the list of matches of that team
        Predicate<Match<FootballTeam>> findMatchesTeam = p -> p.getLocalTeam().equals(t)
            || p.getVisitorTeam().equals(t);
        //We take a list of matches played by that team
        List<Match<FootballTeam>> lm = listFootballMatches.stream().filter(findMatchesTeam).collect(Collectors.toList());
        if(lm == null){
            System.out.println("There are no matches to show");
            return;
        }
        System.out.printf("Showing matches for %s:%n", t.getTeamName()); //Print which team are we managing
        // Print results
        lm.forEach(p -> {
            //First we print teams and score
            System.out.printf("%s %d %s %d", p.getLocalTeam().getTeamName(),
            p.getLocalScore(), p.getVisitorTeam().getTeamName(), p.getVisitorScore());
            //Then if that match is won/lost/Drawn
            if(winFootball(p, t))
                System.out.printf(" (Won)%n");
            else if(looseFootball(p,t))
                System.out.printf(" (Lost)%n");
            else
                System.out.printf(" (Drawn)%n");
        });
    }
    /**
     * Check if match is won
     * @param p match to deal with
     * @param f FootballTeam given by user
     * @return true if the team has won the match
     */
    private static boolean winFootball(Match<FootballTeam> p, FootballTeam f){
        return (p.getLocalTeam().equals(f) && p.getLocalScore() > p.getVisitorScore())
            || (p.getVisitorTeam().equals(f) && p.getLocalScore() < p.getVisitorScore());
    }
    /**
     * Check if match is lost
     * @param p match to deal with
     * @param f FootballTeam given by user
     * @return true if the team has lost the match
     */
    private static boolean looseFootball(Match<FootballTeam> p, FootballTeam f){
        return (p.getLocalTeam().equals(f) && p.getLocalScore() < p.getVisitorScore())
            || (p.getVisitorTeam().equals(f) && p.getLocalScore() > p.getVisitorScore());
    }
    /**
     * Print matches results of basketballTeam
     * @param code teamCode
     */
    private static void showBasketballResults(String code){ //Same procedure than football results
        BasketballTeam t = FileUtils.findTeamBasketballByCode(code, listTeamsBasketball);
        if(t == null)
            return;
        Predicate<Match<BasketballTeam>> findMatchesTeam = p -> p.getLocalTeam().equals(t)
            || p.getVisitorTeam().equals(t);
        List<Match<BasketballTeam>> lm = listBasketballMatches.stream().filter(findMatchesTeam).collect(Collectors.toList());
        if(lm == null)
            return;
        System.out.printf("Showing matches for %s:%n", t.getTeamName());
        lm.forEach(p -> {
            System.out.printf("%s %d %s %d", p.getLocalTeam().getTeamName(),
            p.getLocalScore(), p.getVisitorTeam().getTeamName(), p.getVisitorScore());
            if(winBasketball(p, t))
                System.out.printf(" (Won)%n");
            else
                System.out.printf(" (Lost)%n");
        });
    }
    /**
     * check if match has been won by team given by user
     * @param p match to deal with
     * @param f basketballTeam given by user
     * @return true if the match has been won by given team
     */
    private static boolean winBasketball(Match<BasketballTeam> p, BasketballTeam f){
        return (p.getLocalTeam().equals(f) && p.getLocalScore() > p.getVisitorScore())
            || (p.getVisitorTeam().equals(f) && p.getLocalScore() < p.getVisitorScore());
    }
}