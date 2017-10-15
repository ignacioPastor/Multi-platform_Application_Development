
package libraryex4;

/**
 *
 * @author Ignacio
 */
public class WSOkResponse {
    private boolean ok;
    private String error;

    public WSOkResponse() {
    }

    public WSOkResponse(boolean ok, String error) {
        this.ok = ok;
        this.error = error;
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
    
}
