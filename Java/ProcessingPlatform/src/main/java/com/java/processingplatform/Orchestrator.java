/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.java.processingplatform;

import static com.java.processingplatform.WordFinder.findMatchingWord;

/**
 *
 * @author malor
 */
public class Orchestrator {
        
        /* Constructeur commenter pour la phase de test
        public Orchestrator(String textDocument) {
            int number = findMatchingWord(textDocument);

            //Calcule nb mot dans la phrase
            String[] words = textDocument.split("\\s+");

            float coverage = (float)((number*100)/words.length); 
            System.out.println(coverage + "%");
        }*/
    
        
        
        public static void main(String[] args) {
            String phrase = "Bonjour ceci est un test avec un mot qui existe pas aaeaf";
        
            int number = findMatchingWord(phrase);

            //Calcule nb mot dans la phrase
            String[] words = phrase.split("\\s+");

            float coverage = (float)((number*100)/words.length); 
            System.out.println(coverage + "%");

        }
        
        
    
}
