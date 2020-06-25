/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.java.processingplatform;

import java.util.List;

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
   
}
