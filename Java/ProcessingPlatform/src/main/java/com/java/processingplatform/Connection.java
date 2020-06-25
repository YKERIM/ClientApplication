/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.java.processingplatform;

import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.List;

/**
 *
 * @author malor
 */
public class Connection implements IConnection {
    
    private static final String CONNECTURL = "jdbc:oracle:thin:@localhost:1522:xe";
    private static final String USERNAME = "system";
    private static final String PASSWORD = "root";
    
    public void connection(){  
        
        System.out.println("launch");
        
        try{  

            try (java.sql.Connection con = DriverManager.getConnection(CONNECTURL,USERNAME,PASSWORD)) {

                Statement stmt = con.createStatement();

                ResultSet rs = stmt.executeQuery("SELECT owner, table_name FROM all_tables");
                System.out.println(rs);
                while (rs.next()) {
                    System.out.println(rs.getString(1)+"  "+rs.getString(2));  
                }

            } catch(Exception e){ 
                System.out.println(e);
            }  

        } catch(Exception e){ 
            System.out.println(e);
        }  

    }    

    public static List<String> getListWord() {
        
        List<String> listWord = "test";
        
        return listWord;
    }
}
