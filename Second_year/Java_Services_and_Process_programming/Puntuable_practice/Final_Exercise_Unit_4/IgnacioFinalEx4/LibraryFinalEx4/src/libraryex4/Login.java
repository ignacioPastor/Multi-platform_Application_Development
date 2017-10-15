
package libraryex4;

/**
 * Characterizes the login resource por user
 * @author Ignacio Pastor Padilla
 */
public class Login {
    private String login;
    private String password;
    /**
     * Void constructor
     */
    public Login() {
        this.login = null;
        this.password = null;
    }
    /**
     * Overload constructor
     * @param login
     * @param password 
     */
    public Login(String login, String password) {
        this.login = login;
        this.password = password;
    }
    /**
     * Getter of login
     * @return login
     */
    public String getLogin() {
        return login;
    }
    /**
     * Setter of login
     * @param login new value for login 
     */
    public void setLogin(String login) {
        this.login = login;
    }
    /**
     * Getter of password
     * @return password
     */
    public String getPassword() {
        return password;
    }
    /**
     * Setter of password
     * @param password new value for password
     */
    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public String toString() {
        return "Login [" + "login=" + login + ", password=" + password + "]";
    }
    
}
