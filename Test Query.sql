--Tutte le date si assumono memorizzate senza orario


--Targa e Marca delle Auto di cilindrata superiore a 2000 cc 
--o di potenza superiore a 120 CV 
Select	Targa,
		Marca
From	[Auto]
Where	Cilindrata > 2000
	Or	Potenza > 120


--Nome del proprietario e Targa delle Auto di cilindrata superiore a 2000 cc 
--oppure di potenza superiore a 120 CV
Select	t1.Nome As 'Proprietario',
		t0.Targa
From	[Auto] t0
			Inner Join Proprietari t1
				On	t0.CodF = t1.CodF
Where	t0.Cilindrata > 2000
	Or	t0.Potenza > 120

--Targa e Nome del proprietario delle Auto di cilindrata superiore a 2000 cc 
--oppure di potenza superiore a 120 CV, assicurate presso la “SARA”
Select	t0.Targa,
		t1.Nome As 'Proprietario'
From	[Auto] t0
			Inner Join Proprietari t1
				On	t0.CodF = t1.CodF
			Inner Join Assicurazioni t2
				On	t0.CodAss = t2.CodAss
Where	(t0.Cilindrata > 2000
	Or	t0.Potenza > 120)
	And	t2.Nome = 'SARA'

--Targa e Nome del proprietario delle Auto assicurate presso la “SARA” 
--e coinvolte in sinistri il 20/01/02
Select	Distinct
		t0.Targa,
		t1.Nome As 'Proprietario'
From	[Auto] t0
			Inner Join Proprietari t1
				On	t0.CodF = t1.CodF
			Inner Join Assicurazioni t2
				On	t0.CodAss = t2.CodAss
			Inner Join AutoCoinvolte t3
				On	t0.Targa= t3.Targa
			Inner Join Sinistri t4
				On	t3.CodS = t4.CodS
Where	t2.Nome = 'SARA'
	And	t4.[Data] = '20020120' --yyyyMMdd

--Per ciascuna Assicurazione, il nome, la sede ed il numero di auto assicurate
Select	t0.Nome As 'Assicurazione',
		t0.Sede,
		Sum(Case
				When t1.Targa Is Null Then 0
				Else 1
			End)  As 'N. auto assicurate'
From	Assicurazioni t0
			Left Join [Auto] t1
				On	t0.CodAss = t1.CodAss
Group
By		t0.Nome,
		t0.Sede

--Per ciascuna auto “Fiat”, la targa dell’auto ed il numero di sinistri 
--in cui è stata coinvolta
Select	t0.Targa,
		Sum(Case
				When t1.CodS Is Null Then 0
				Else 1
			End) As 'N. sinistri'
From	[Auto] t0
			Left Join AutoCoinvolte t1
				On	t0.Targa= t1.Targa
Where	t0.Marca = 'Fiat'
Group
By		t0.Targa

--Per ciascuna auto coinvolta in più di un sinistro, la targa dell’auto, 
--il nome dell’Assicurazione, ed il totale dei danni riportati 
Select	t0.Targa,
		t2.Nome As 'Assicurazione',
		Sum(t1.ImportoDelDanno) As 'Totale danni'
From	[Auto] t0
			Inner Join AutoCoinvolte t1
				On	t0.Targa= t1.Targa
			Inner Join Assicurazioni t2
				ON	t0.CodAss = t2.CodAss
Group
By		t0.Targa,
		t2.Nome
Having	Count(1) > 1

--CodF e Nome di coloro che possiedono più di un’auto
Select	t0.CodF,
		t0.Nome
From	Proprietari t0
			Inner Join [Auto] t1
				On	t0.CodF = t1.CodF
Group
By		t0.CodF,
		t0.Nome
Having	Count(1) > 1

--La targa delle auto che non sono state coinvolte in sinistri dopo il 20/01/01
Select	t0.Targa
From	[Auto] t0
			Left Join	(
						Select	Distinct
								t1.Targa
						From	AutoCoinvolte t1
									Inner Join Sinistri t2
										On	t1.CodS= t2.CodS
						Where	t2.[Data] > '20010120'	--yyyyMMdd
						) t3
				On	t0.Targa = t3.Targa
Where	t3.Targa Is Null
			
--Il codice dei sinistri in cui non sono state coinvolte auto con cilindrata inferiore a 2000 cc
Select	Distinct
		t1.CodS
From	[Auto] t0
			Inner Join AutoCoinvolte t1
				On	t0.Targa= t1.Targa
Where	t0.Cilindrata < 2000