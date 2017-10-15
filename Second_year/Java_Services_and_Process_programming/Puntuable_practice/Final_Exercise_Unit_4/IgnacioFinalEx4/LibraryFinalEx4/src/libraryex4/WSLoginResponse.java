
package libraryex4;

/**
 *
 * @author Ignacio
 */
public class WSLoginResponse {
    private boolean ok;
    private String error;
    private String token;

    public WSLoginResponse() {
    }

    public WSLoginResponse(boolean ok, String error, String token) {
        this.ok = ok;
        this.error = error;
        this.token = token;
    }

    public boolean isOk() {
        return ok;
    }

    public void setOk(boolean ok) {
        this.ok = ok;
    }

    public String getError() {
        return error;
    }

    public void setError(String error) {
        this.error = error;
    }

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

    @Override
    public String toString() {
        return "WSLoginResponse [" + "ok=" + ok + ", error=" + error + ", token=" + token + "]";
    }
    
}
