/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.java.processingplatform;

import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author malor
 */
public class Connection implements IConnection {
    
    private static final String CONNECTURL = "jdbc:oracle:thin:@localhost:1522:xe";
    private static final String USERNAME = "system";
    private static final String PASSWORD = "root";
    
    public static List<String> getListWord() {
        
        List<String> listWord = new ArrayList<>();
        
        try{  

            try (java.sql.Connection con = DriverManager.getConnection(CONNECTURL,USERNAME,PASSWORD)) {

                Statement stmt = con.createStatement();

                ResultSet rs = stmt.executeQuery("SELECT regexp_replace(WORD, '[[:space:]]*','') FROM DICTIONNARY");
                while (rs.next()) {
                    listWord.add(rs.getString(1));  
                }
                
                con.close(); 

            } catch(Exception e){ 
                System.out.println(e);
            }  

        } catch(Exception e){ 
            System.out.println(e);
        }  
        
        return listWord;
    }
}
