alter table mytable
add constraint DF_mytblid //nombre de la constraint
default next value for mainseq
for id //columna de la tabla 


create sequence mainseq as bigint start with 1 //aca deberiamos seleccionar el mas grande cada tabla
	increment by 1