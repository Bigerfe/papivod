  function titleFlag(obj)
    {
       var t = document.getElementById("NewsTitle");
      if(t.value!="")
      {
       t.value = obj + t.value;
       }
       else
       {
         t.value = obj;
       }
    }
   function addSource(obj){document.getElementById("Souce").value= obj;}
    
    function addAuthor(obj){document.getElementById("Author").value= obj;}
    function addTags(obj)
    {
        var s = document.getElementById("Tags").value;
        if(s!="")
        {
            if(s.indexOf(obj)==-1)
            {
                document.getElementById("Tags").value= s + "|" +obj;
            }
        }
        else
        {
            document.getElementById("Tags").value= obj;
        }
    }
