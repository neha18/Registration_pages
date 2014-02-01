      
      function ShowHome() {
      //new_win = window.open("MainPage.aspx","toolbar=no,menubar=0,status=0,copyhistory=0,scrollbars=yes,resizable=1,location=0,Width=1500,Height=760");    
        new_win = window.open("MainPage.aspx?lev=1");
               }
               function ShowMain()
               {
                 new_win = window.open("Login.aspx");
               }
                 function IAmSelected( source, eventArgs ) {
                 var bc = new Array (); 
                 var bca =  eventArgs.get_value();
                  bc = bca.split(',');
       var searchText = source.get_element();
       searchText.value = bc[0]; //eventArgs.get_value();
     
}
 function IAmSelectedn( source, eventArgs ) {
                 var bc = new Array (); 
                 var bca =  eventArgs.get_value();
                  bc = bca.split(',');
       var searchText = source.get_element();
       searchText.value = bca ; //eventArgs.get_value();
     
}
  function txtfoc(txtcode)
      {
       setTimeout(function() {
       document.getElementById(txtcode).focus();}, 60);                                     
      }
        function focus( source, eventArgs ) { 
            var bc = new Array (); 
            var bca =  eventArgs.get_value();
             bc = bca.split(',');
            var searchText = source.get_element();
                searchText.value = bc[0];    
            setTimeout(function() {
              source.get_element().focus();}, 0);                 /// <reference path="JSpub.js" />
                    
        }
         function focusn( source, eventArgs ) { 
            var bc = new Array (); 
            var bca =  eventArgs.get_value();
           
            var searchText = source.get_element();
                searchText.value = bca;    
            setTimeout(function() {
              source.get_element().focus();}, 0);                                     
        }
      function isPhoneNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 32 && (charCode < 48 || charCode > 57))
            return false;

         return true;
      }
      function isLandNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : event.keyCode
         //alert (charCode );
         if (charCode > 32 && ( charCode < 45 ||charCode == 46 || charCode == 47  || charCode > 57) )
            return false;

         return true;
      }
                //mobile number validation
         function Pin(txtCode)
        {
           
            var y= document.getElementById(txtCode).value
                
           if (y.length !=6&&y.length!=0)
           {
                alert ('Please Check PinCode'); 
                   setTimeout(function() {
                   document.getElementById(txtCode).focus();}, 0);                                     
                                
           }
          
        }
        function ValidateMultiPhone(txtCode)
        {  
            var phnnum = new Array ();
            var y= document.getElementById(txtCode).value;
            y=trim(y);           
            phnnum = y.split(' '); 
                   
            if(y.toString()!= "")
            {
            if(phnnum [0]=="")
            {
              alert ('Please do not add space in starting of number'); 
                   setTimeout(function() {
                   document.getElementById(txtCode).focus();}, 0);                                     
                                
            }            
            else 
            {
            for(var i = 0 ; i<phnnum.length ; i++)
            {       
            var f = phnnum [i].charAt(0);
            if(f=="0")
            {
             alert ('Please do not add 0 in starting of number'); 
                   setTimeout(function() {
                   document.getElementById(txtCode).focus();}, 0);                                     
            }      
            if (phnnum [i].length > 10||phnnum [i].length < 10)
                 {
                    
                   alert (phnnum [i] + ' is invalid phone number');                   
                  // document.getElementById(txtCode).style.color = "red";
                   setTimeout(function() {
                   document.getElementById(txtCode).focus();}, 0);                                     
                  }
                  else 
                  {
                   document.getElementById(txtCode).style.color = "black";                  
                  }           
             }       
            } 
          }                                                
        }
        //validation for landline number
        function checkPhone(chk){         
        var landnum = new Array ();
         var match1;
          var y= document.getElementById(chk).value;
          y=trim(y);        
          landnum = y.split(' ');
          var phnmatcpart = /^[0-9]\d{2,4}-\d{6,8}$/;
         
          if (y.toString()!=="")
          {
           if(landnum[0]=="")
            {
              alert ('Please do not add space in starting of number');
              setTimeout(function() {document.getElementById(chk).focus();}, 0);                
                   
            }
            else 
            {
           for(var i = 0 ; i<landnum.length ; i++)
            {
            match1 = landnum[i].match(phnmatcpart);
	        if(match1==null ){
	        	alert(landnum[i]+ " Bad phone number. Try again.");
	            setTimeout(function() {document.getElementById(chk).focus();}, 0);                
	            }
	        }
           }
          }
        }   
        function trim(s)
{
	var l=0; var r=s.length -1;
	while(l < s.length && s[l] == ' ')
	{	l++; }
	while(r > l && s[r] == ' ')
	{	r-=1;	}
	return s.substring(l, r+1);
}
       function warehouse(evt, warval , drop)
         {         
         var war = warval.toString ();       
           if(war=="" || war == "-Select-")
             {             
               alert ("Please select a Warehouse");             
               return false  ;
             }
            else 
             {
              return  true;
             }        
         }
         function validateEmail(field) {
    var regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,5}$/;
    return (regex.test(field)) ? true : false;
}
 function emailvalidate(txtemail)
 {
   var emailidpart = new Array ();
   var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
   var emailid= document.getElementById(txtemail).value;
   var matchArray ;
   emailidpart = emailid.split(' ');
   if(emailid.toString()!="")
   {
     if(emailidpart[0]=="")
            {
              alert ('Please do not add space in starting of Email ID');  
              setTimeout(function() {document.getElementById(txtemail).focus();}, 0);                                 
            }
            else 
            {  
    for(var i = 0 ; i<emailidpart.length ; i++)
      {            
        if (!validateEmail(emailidpart[i]))
        {
         alert(emailidpart[i]+ " email address seems incorrect. Please try again.");
          setTimeout(function() {document.getElementById(txtemail).focus();}, 0);                
         return false ;       
        }

      }
      }
   }
 }
      function isDATENumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode >= 1 && charCode <= 127)
            return false;

         return true;
      }
      
      
//FUNCTION TO CREATE SHORTCUT MODELPOPUP      
      
      
 var isCtrl = false;
function up(e){
	if(e.which == 17) isCtrl=false;
}
function down(e){
var modalDialog = $find("ModalPopupExtender1"); 
	if(e.which == 17) isCtrl=true;
	//ctrl+c to open New identity
	if(e.which == 68 && isCtrl == true) {		
		 if (modalDialog != null) {    
		
         document.getElementById("frame1").src ="Coustomer1.aspx?mode=model";  
         document.getElementById("frame1").width ="980px";  
         document.getElementById("frame1").height ="540px";  
          document.getElementById("overlay").style.visibility = "visible";      
         modalDialog.show();
             }  		
		return false;
	}
	//ctrl+i to open Add More Information	
	if(e.which == 73 && isCtrl == true) {		
		 if (modalDialog != null) {         
		
         document.getElementById("frame1").src ="AddUCS.aspx?mode=model";  
         document.getElementById("frame1").width ="600px";  
         document.getElementById("frame1").height ="500px";  
         document.getElementById("overlay").style.visibility = "visible"; 
         modalDialog.show();
             }  		
		return false;
	}
	//ctrl+t to open Transport	
	if(e.which == 84 && isCtrl == true) {
		 if (modalDialog != null) {         
		 
         document.getElementById("frame1").src ="TransportDetail.aspx?mode=model";  
         document.getElementById("frame1").width ="600px";  
         document.getElementById("frame1").height ="270px";  
        document.getElementById("overlay").style.visibility = "visible"; 
         modalDialog.show();
             }  
		return false;
	}
	//ctrl+b to open BookDetail	
	if(e.which == 66 && isCtrl == true) {
		 if (modalDialog != null) {         
		 
         document.getElementById("frame1").src ="BookDetail.aspx?mode=model";  
         document.getElementById("frame1").width ="600px";  
         document.getElementById("frame1").height ="400px";  
         document.getElementById("overlay").style.visibility = "visible"; 
         modalDialog.show();
             }  
		return false;
	}
	//ctrl+w to open New WareHouse	
	if(e.which == 87 && isCtrl == true) {
		 if (modalDialog != null) {         
         document.getElementById("frame1").src ="New WareHouse.aspx?mode=model";  
         document.getElementById("frame1").width ="990px";  
         document.getElementById("frame1").height ="600px";  
       	 document.getElementById("overlay").style.visibility = "visible"; 
         modalDialog.show();
             }  
		return false;
	}
	return true;
}
// function for controlling div width according to browser resize

function changeWidth()
        {
         
          var elem = document.getElementById("MainDiv");
          var t =screen.width;          
          elem.style.width = t+"px";
          elem.style.position = 'absolute';
        }
        
        
//         window.onbeforeunload = function() {
//  return "Are you sure you wish to leave this delightful page?";
//}


  function setHW() {
        var modalDialog = $find("mdl1"); 
        
         var w =screen.width-30;  
         
         var h = screen.height-140;  
         if (modalDialog != null) {           
            document.getElementById("frame1").width = w+"px";  
         document.getElementById("frame1").height = h+"px"      
            }
        }
        
   function setHWNEW() {
         var modalDialog = $find("mdl1"); 
         var c = ((screen.width * 5)/100)*2;
         c = c+45;
         var w =screen.width- parseInt(c);  
         var h = screen.height-320;  
         if (modalDialog != null) {  
             
            document.getElementById("frame1").width = w+"px";  
            document.getElementById("frame1").height = h+"px"      
            }
        }
        
        function setHWNEW2() {
       var modalDialog = $find("mdl1"); 
         var c = ((screen.width * 5)/100)*2;
         c = c+55;
         var w =screen.width- parseInt(c);  
         var h = screen.height-320;  
         if (modalDialog != null) {  
             
            document.getElementById("frame1").width = w+"px";  
            document.getElementById("frame1").height = h+"px"      
            }
        }
     function ValidateOGBY()
      {
        var ogb =  document.getElementById ('DropOGB').value;
     
          if(ogb == "Marketing Executive")
            {
             if(document.getElementById('dropS').value=="-Select-")
                {
                    alert("Please Fill Marketing Executive");
                    return false;
                }
            }
          else if(ogb == "Commission Agent")
          {         
          if(document.getElementById ('dropS').value=="-Select-")
            {
            
                alert("Please Fill Commision Agent");
                return false;
            }
          }  
          else if(ogb == "Others")
          {         
          if(document.getElementById ('txtS').value=="")
            {
            
                alert("Please Enter Details");
                return false;
            }
          }  
          return true;
        }
        
        
      function ValidateOGBYPer()
      {
        var ogb =  document.getElementById ('txtOGB').value;
         var disp = document.getElementById ('txtDISP').value;
         if(document.getElementById('DRToc').value=="-Select-"){
         alert("Please Select Type Of Order");
                    return false;
         }
         if(document.getElementById('txtPost').value==""){
          alert("Please Fill Postage");
                    return false;
         }
          if(ogb == "Marketing Executive")
            {
             if(document.getElementById('txtICG').value=="")
                {
                    alert("Please Fill Marketing Executive");
                    return false;
                }
            }
          else if(ogb == "Commission Agent")
          {         
          if(document.getElementById ('txtICG').value=="")
            {
            
                alert("Please Fill Commision Agent");
                return false;
            }
          }  
          else if(ogb == "Others")
          {         
          if(document.getElementById ('txtICG').value=="")
            {
            
                alert("Please Enter Details");
                return false;
            }
          }
       
         if(disp =="By Hand")
         {                   
           if(document.getElementById ('txtCons').value=="")
            {
            
                alert("Please Enter ConSignee Name");
                return false;
            }
          if(document.getElementById ('txtBDS').value=="")
            {
            
                alert("Please Enter Delivery Station");
                return false;
            }
          }                                                       
         else if(disp == "By Transport")
         {
         if(document.getElementById ('DropTransport').value=="")
            {
            
                alert("Please Enter Transport Name");
                return false;
            }
          if(document.getElementById ('txtBN').value=="")
            {
            
                alert("Please Enter GR No");
                return false;
            }
         if(document.getElementById ('txtBAN').value=="")
            {
            
                alert("Please Enter Bank Details");
                return false;
            }
          if(document.getElementById ('txtDS').value=="")
            {
            
                alert("Please Enter Delivery Station");
                return false;
            }                                            
         }
         else if(disp =="By Bus"){
         if(document.getElementById ('txtBBNom').value=="")
            {
            
                alert("Please Enter Bus No");
                return false;
            }
          if(document.getElementById ('txtBBDS').value=="")
            {
            
                alert("Please Enter Delivery Station");
                return false;
            }    
                  
         }
         else if(disp == "By Cargo"){
          if(document.getElementById ('txtCar').value=="")
            {
            
                alert("Please Enter Cargo Name");
                return false;
            }
          if(document.getElementById ('txtCD').value=="")
            {
            
                alert("Please Enter Cargo Details");
                return false;
            }    
              if(document.getElementById ('txtCRDS').value=="")
            {
            
                alert("Please Enter Delivery Station");
                return false;
            }                                               
         }
         else if(disp == "By Courier"){
          if(document.getElementById ('txtNOT').value=="")
            {
            
                alert("Please Enter Nature Of Courier");
                return false;
            }
          if(document.getElementById ('txtBCCN').value=="")
            {            
                alert("Please Enter Courier Name");
                return false;
            }    
              if(document.getElementById ('txtBCNOP').value=="")
            {
            
                alert("Please Enter No Of Packets");
                return false;
            } 
             if(document.getElementById ('txtBCPON').value=="")
            {
            
                alert("Please Enter Packet Office No");
                return false;
            }    
              if(document.getElementById('txtBCDS').value=="")
            {
            
                alert("Please Enter Delivery Station");
                return false;
            }                                              
         }
      return true;                
        }
       //validation for landline number
        function checkPhonegrid(chk,cod){  
               
        var landnum = new Array ();
         var match1;
          var y= document.getElementById(chk).value;
          var c = document.getElementById(cod).value;  
          if(c!=""){               
          y=trim(y);        
          landnum = y.split(' ');
          var phnmatcpart = /^[0-9]\d{2,4}-\d{6,8}$/;
         
          if (y.toString()!=="")
          {
           if(c+"-"+landnum[0] =="")
            {
              alert ('Please do not add space in starting of number');
              setTimeout(function() {document.getElementById(chk).focus();}, 0);                                   
            }
            else 
            {
           for(var i = 0 ; i<landnum.length ; i++)
            {
            var t = c+"-"+landnum[i];            
            match1 = t.match(phnmatcpart);
	        if(match1==null ){
	        	alert(t + " Bad phone number. Try again.");
	            setTimeout(function() {document.getElementById(chk).focus();}, 0);                
	            }
	        }
           }
          }        
        }        
        }
     function isLandNumberKeygrid(evt, cod)
      {
        var c = document.getElementById(cod).value;
          if(c=="S.T.D")
          {
          alert ("Please Fill Std Code first");
           return false;
          }
          else {  
         var charCode = (evt.which) ? evt.which : event.keyCode
         //alert (charCode );
         if (charCode > 32 && ( charCode < 45 ||charCode == 46 || charCode == 47  || charCode > 57) )
            return false;

         return true;
         }
      }
      
       function isNumberKey(evt)
      {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

         return true;
      }
      
       function isNumberKeyDis(evt)
      {
      
         var charCode = (evt.which) ? evt.which : event.keyCode       
        
         if (charCode > 31 && (charCode < 43||charCode==44 || charCode==45||charCode==46||charCode==47||charCode>58))
            return false;

         return true;
      }
      
      
        function isCANumberKeyDis(elementRef)
      {
      
         var keyCodeEntered = (elementRef.which) ? elementRef.which : event.keyCode       
         if ( (keyCodeEntered >= 48) && (keyCodeEntered <= 57) || keyCodeEntered == 8 )
               {
                 return true;
               }
           // '+' sign...
        else if ( keyCodeEntered == 43 )
         {
          // Allow only 1 plus sign ('+')...
              if ( (elementRef.value) && (elementRef.value.indexOf('+') >= 0) )
               return false;
             else
             return true;
         }
         else if ( keyCodeEntered == 46 )
              {
            // Allow only 1 decimal point ('.')...
             if ( (elementRef.value) && (elementRef.value.indexOf('.') >= 0) )
               return false;
             else
           return true;
             }
           return false;
          }
     
      
      
     var pan = '#dfe2e1';
 var lab = '#000000'
 
 
function caaaal(p,f)
    {
   
    lab = f;
    if(pan != 'no')
    {
     
     pan = p;
  
    }
    }

 function getStyle() {

    var classes = document.styleSheets[0].rules || document.styleSheets[0].cssRules
    
    for(var x=0;x<classes.length;x++) {

        if(classes[x].selectorText=='.panel') {
            
          classes[x].style.backgroundColor = pan;         
          
        }
        if(classes[x].selectorText=='.fnt') {
            
        
          classes[x].style.color = lab;         
          
        }
    }
}
      