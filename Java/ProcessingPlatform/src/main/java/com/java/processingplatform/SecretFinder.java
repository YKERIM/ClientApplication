/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.java.processingplatform;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 *
 * @author malor
 */
public class SecretFinder {
    
    private final String secretMessage = "information secrÃ¨te|information secrète|information secrete";
    
    public boolean findSecretWord(String message) {
        
        String patternString = "\\b("+ secretMessage +")\\b";
        Pattern pattern = Pattern.compile(patternString,Pattern.CASE_INSENSITIVE);
        Matcher matcher = pattern.matcher(message);

        if (matcher.find()) {
            return true;
        } else {
            return false;
        }
        
    }
}
