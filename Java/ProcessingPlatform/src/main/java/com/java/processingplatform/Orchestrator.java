/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.java.processingplatform;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author malor
 */
public class Orchestrator {
        
        //Constructeur commenter pour la phase de test
        public Orchestrator(FileToCheck fileToCheck) {
            
            String textDocument = fileToCheck.getFile();
            
            WordFinder wordFinder = new WordFinder();
            int numberValideWord = wordFinder.findMatchingWord(textDocument);

            //Calcule nb mot dans la phrase
            String[] words = textDocument.split("\\s+");

            float coverage = (float)((numberValideWord*100)/words.length); 
            System.out.println(coverage + "%");
            
            //Contient le mot secret
            SecretFinder secretFinder = new SecretFinder();
            String secretWord = secretFinder.findSecretWord(textDocument);
            System.out.println("Information trouvée : " + secretWord);
            
            if (coverage >= 65 && secretWord == "true") {
                try {
                    sendMessage(fileToCheck.getFileName(),fileToCheck.getKey(),secretWord);
                } catch (IOException ex) {
                    Logger.getLogger(Orchestrator.class.getName()).log(Level.SEVERE, null, ex);
                }
            }
            
        }     
        
        public void sendMessage(String fileName, String key, String secretMessage) throws IOException {
            
            String separator = "%7C";
            String space = "%20";
            String Url = "http://localhost:64046/ServiceClient.svc/getJavaFile/";
            
            //Transform secretMessage space by space character
            secretMessage = secretMessage.replaceAll("\\s",space);
            
            //Start connection
            URL obj = new URL(Url+fileName+separator+key+separator+secretMessage);
            HttpURLConnection con = (HttpURLConnection) obj.openConnection();
                con.setRequestProperty("User-Agent", "Mozilla/5.0");
                               
		int responseCode = con.getResponseCode();
                
		System.out.println("GET Response Code :: " + responseCode);
		if (responseCode == HttpURLConnection.HTTP_OK) { // success
			BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));
			String inputLine;
			StringBuffer response = new StringBuffer();

			while ((inputLine = in.readLine()) != null) {
				response.append(inputLine);
			}
			in.close();

			// print result
			System.out.println(response.toString());
		} else {
			System.out.println("GET request not worked");
                        
		}
                con.disconnect();
        }
        
}
