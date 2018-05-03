import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
 
import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.SwingUtilities;
 
public class LogListener  {
   
    private final JFrame frame;
    private LogPanel logPanel;
    private ShowAdminPanel showAdminPanel;
    
    //do logowania
    //ograniczony dostep
  	private static final String name1 = "Janina";
    private static final String password1 = "1234";
    //admin
    private static final String name2 = "root";
    private static final String password2 = "toor";
    
    static boolean flagaPracownik;
    static boolean flagaAdministrator;
 
   /* public void setPanel(AdminPanel adminPanel) {
        this.AdminPanel = adminPanel;
    }*/
 
    public LogListener(JFrame frame) {
        this.frame = frame;
    }
   
      public static boolean authenticate(String name, String password) {
          
    	  flagaPracownik = false;
    	  flagaAdministrator = false;
    	  if(name1.equals(name) & password1.equals(password))
          {
        	  flagaPracownik = true;
        	  return true;
          }        
          else
              {
          	if(name2.equals(name) & password2.equals(password))
          	{
          		flagaAdministrator = true;
          		return true;
          	}       		
          	else
          		return false;
              }
          
      }
 
    }
