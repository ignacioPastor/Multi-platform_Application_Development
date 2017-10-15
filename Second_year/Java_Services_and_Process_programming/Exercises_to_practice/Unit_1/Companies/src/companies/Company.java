
package companies;

/**
 * Characteryze the Company
 * @author Ignacio
 */
public class Company implements Comparable<Company>{

    public Company(){
        
    }
    public Company(String name, double money){
        this.name = name;
        this.money = money;
    }
    String name;
    double money;
    
    public String getName(){
        return name;
    }
    public double getMoney(){
        return money;
    }

    @Override
    public int compareTo(Company o) {
        if(this.money > o.money)
            return -1;
        else if(this.money < o.money)
            return 1;
        else
            return 0;
    }
    
}
