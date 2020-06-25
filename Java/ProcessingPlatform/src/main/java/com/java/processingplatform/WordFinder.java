/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.java.processingplatform;

import java.util.ArrayList;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 *
 * @author malor
 */
public class WordFinder {
    
    private static List<String> dictionary;
    
    WordFinder() {
        if (dictionary == null) {
            dictionary = Connection.getListWord();
        }
        
       
    }
    
    public static void findMatchingWord(String testingWord) {
        
        List<String> tokens = new ArrayList<String>();
        
        StringBuilder sb = new StringBuilder( "\\b(" );
        String del = "";
        for( String element: dictionary ){
            sb.append( del ).append( element );
            del = "|";
        }
        String patternString = sb.toString() + ")\\b";
        System.out.println(patternString);

        Pattern pattern = Pattern.compile(patternString);
        Matcher matcher = pattern.matcher(testingWord);

        while (matcher.find()) {
            System.out.println(matcher.group(1));
        }
        
    }
    
    
    public static void main(String[] args) {
        dictionary = Connection.getListWord();
        
        for( String element : dictionary ) {
            System.out.println( element );
        }
           
        String phrase = "Bonjour ceci est un teste avec un mot qui existe pas aaeaf";
        findMatchingWord(phrase);
   }
   
}
