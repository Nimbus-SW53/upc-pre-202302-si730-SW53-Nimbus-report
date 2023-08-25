<<<<<<< HEAD
﻿namespace WebApplication2.Model;

public class Nimbus
{   
      
    public int id { get; set; }

    public string category { get; set; }

    public string service { get; set; }

    public double price { get; set; }
    public List<Nimbus> listado()
    {
        List<Nimbus> nimbus = new List<Nimbus>();
        nimbus.Add(new Nimbus { id = 1, category = "Provedor", price = 59.99, service = "AWS" });
        nimbus.Add(new Nimbus { id = 2, category = "Provedor", price = 69.99, service = "Azure" });
        nimbus.Add(new Nimbus { id = 3, category = "Servidor", price = 45.99, service = "Google Cloud" });

        return nimbus;
    }
}
    
    
    
    
    
    
    
=======
﻿namespace WebApplication2.Model;

public class Nimbus
{   
      
    public int id { get; set; }

    public string category { get; set; }

    public string service { get; set; }

    public double price { get; set; }
    public List<Nimbus> listado()
    {
        List<Nimbus> nimbus = new List<Nimbus>();
        nimbus.Add(new Nimbus { id = 1, category = "Provedor", price = 59.99, service = "AWS" });
        nimbus.Add(new Nimbus { id = 2, category = "Provedor", price = 69.99, service = "Azure" });
        nimbus.Add(new Nimbus { id = 3, category = "Servidor", price = 45.99, service = "Google Cloud" });

        return nimbus;
    }
}
    
    
    
    
    
    
    
>>>>>>> 5477b4cce927992080c7c16661dd54dd86080498
