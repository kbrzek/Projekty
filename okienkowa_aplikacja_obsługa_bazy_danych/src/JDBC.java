import java.sql.*;
import java.util.*;
import java.util.Vector;

public class JDBC {

	protected String url;
	protected String username;
	protected String password;
	protected Connection con;
	protected Statement stat;
	protected ResultSet rset;
	protected Vector kolumny=new Vector();
	protected Vector dane=new Vector(7);
	
	protected JDBC()
	{		
		url = "jdbc:oracle:thin:@ora3.elka.pw.edu.pl:1521:ora3inf";
		username = "azadrozn";
		password = "WBD_jest!";
	}
	
	public void startJDBC()
	{
		System.out.println("Start JDBC program.."); 
		
		try {
			DriverManager.registerDriver(new oracle.jdbc.OracleDriver());
			Class.forName("oracle.jdbc.OracleDriver");
			System.out.println("Connecting to database.."); 
			con = DriverManager.getConnection(url, username, password);
			stat = con.createStatement();
			
		}
		catch(ClassNotFoundException e)
		{
			e.printStackTrace();
		}
		catch(SQLException e)
		{
			e.printStackTrace();
		}
	}
	
	public void close()
	{
		try
		{
			//sql = "SELECT ID_Biura, Nazwa_Biura FROM Biura WHERE Ulica = 'Chmielna'";

			//rset = stat.executeQuery(sql);
			
			//rset.last();
			//int count = rset.getRow();
			
			//System.out.println("Liczba rekordów: "+count);
			
			//rset.beforeFirst();
			//int i = 0;
			
			/*switch(ShowAdminFrame.chosenTab)
			{
			case "Biura":
			{
				while(rset.next())
				{
					//int ID_Biuraa = rset.getInt(1);
					//String Nazwa_Biuraa = rset.getString(2);//"Nazwa_Biura");
					//System.out.println("ID Biura: " + ID_Biuraa + " Nazwa biura: " + Nazwa_Biuraa );
					Vector row = new Vector(9);
					row.add(Integer.toString(rset.getInt(1)));
					row.add(rset.getString(2));
					row.add(rset.getString(3));
					row.add(rset.getString(4));
					row.add(rset.getString(5));
					row.add(rset.getString(6));
					row.add(rset.getString(7));
					row.add(Integer.toString(rset.getInt(8)));
					row.add(Integer.toString(rset.getInt(9)));
					dane.add(row);
	            // zmienna=true;
				}
				//System.out.println("Wektor: " + dane);
			}
			*/
		/*	case "Operatorzy":
			{
				while(rset.next())
				{
					int ID_Operatoraa = rset.getInt(1);
					String Nazwa_Biuraa = rset.getString(2);//"Nazwa_Biura");
					System.out.println("ID Operatora: " + ID_Operatoraa + " Nazwa biura: " + Nazwa_Biuraa );
					Vector row = new Vector(7);
					row.add(rset.getInt(1));
					row.add(rset.getString(2));
					row.add(rset.getString(3));
					row.add(rset.getInt(4));
					row.add(rset.getString(5));
					row.add(rset.getString(6));
					row.add(rset.getString(7));
					row.add(rset.getInt(1));
					row.add(rset.getInt(1));
	            // dane.add(row);
	            // zmienna=true;
				}
				
			}*/
			
		/*	case "Pracownicy":
			{
				while(rset.next())
				{
					int ID_Pracownikaa = rset.getInt(1);
					String Nazwa_Biuraa = rset.getString(2);//"Nazwa_Biura");
					System.out.println("ID Pracownika: " + ID_Pracownikaa + " Nazwa biura: " + Nazwa_Biuraa );
					Vector row = new Vector(7);
					row.add(rset.getInt(1));
					row.add(rset.getString(2));
					row.add(rset.getString(3));
					row.add(rset.getInt(4));
					row.add(rset.getString(5));
					row.add(rset.getString(6));
					row.add(rset.getString(7));
					row.add(rset.getInt(1));
					row.add(rset.getInt(1));
	            // dane.add(row);
	            // zmienna=true;
				}
			}
			
			}*/
			rset.close();
			stat.close();
			con.close();
			
			}		
			catch(SQLException e)
			{
				e.printStackTrace();
			}
			
				
		}
	
}
	
