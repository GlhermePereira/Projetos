presidentes :: String -> Bool
presidentes "Lula" = True
presidentes "FHC" = True
presidentes "Itamar" = True
presidentes "Collor" = True
presidentes "Dilma" = True
presidentes "Sarney" = True
presidentes "JK" = True
presidentes = False

---No Console escreva :L main.hs

---brasileiros = [ "Kemelly", "Collor", "Lula", "Jorge"]

---presidas = [ x | x <- brasileiros, presidentes x ]

---presidas