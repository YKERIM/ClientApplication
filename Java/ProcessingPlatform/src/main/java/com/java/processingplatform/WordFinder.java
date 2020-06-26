/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.java.processingplatform;

import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 *
 * @author malor
 */
public class WordFinder {
    
    private static List<String> dictionary = null;
    
    WordFinder() {
        if (dictionary == null) {
            dictionary = Connection.getListWord();
        }
        
       
    }
    
    public static int findMatchingWord(String testingWord) {
        
        int MatchingNumber = 0;
        
        StringBuilder sb = new StringBuilder( "\\b(" );
        String patternString;
        String del = "";
        int ctp = 0;
        
        for( String element: dictionary ){
            
            sb.append( del ).append( element );
            del = "|";
            
            //Decoupage du dictionnaire
            if (ctp == Math.round(dictionary.size()/20)) {

                patternString = sb.toString() + ")\\b";
                Pattern pattern = Pattern.compile(patternString,Pattern.CASE_INSENSITIVE);
                Matcher matcher = pattern.matcher(testingWord);

                while (matcher.find()) {
                    MatchingNumber++;
                }
                
                ctp = 0;
                sb = new StringBuilder( "\\b(" );
                del = "";
                
            }
            ctp++;
        }
        
        patternString = sb.toString() + ")\\b";
        
        
        Pattern pattern = Pattern.compile(patternString,Pattern.CASE_INSENSITIVE);
        Matcher matcher = pattern.matcher(testingWord);

        while (matcher.find()) {
            MatchingNumber++;
        }
        
       return MatchingNumber;
    }   
}
