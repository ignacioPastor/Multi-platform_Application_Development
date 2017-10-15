<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
		<HTML>
			<HEAD>
				<TITLE>Practica 7 - Ignacio Pastor</TITLE>
				<LINK rel="stylesheet" type="text/css" href="css/style_canciones.css" />
			</HEAD>
			<BODY>
				<H1>Repositorio de canciones</H1>
				<xsl:for-each select="//cancion">
					<DIV CLASS="miCancion">
						<H2><U><STRONG>Título de la canción:</STRONG></U>...<xsl:value-of select="@titulo"/></H2>
						<xsl:apply-templates select="artistas"/>
						<xsl:if test="@genero">
							<P id="genero"><STRONG>Género: </STRONG><xsl:value-of select="@genero"/></P>
						</xsl:if>
						<P id="album"><STRONG>Album: </STRONG><xsl:value-of select="album"/></P>
						<P id="anyo"><STRONG>Año: </STRONG><xsl:value-of select="anyo"/></P>
						<P id="ubicacion"><STRONG>Ubicación: </STRONG><xsl:value-of select="ubicacion"/></P>
						<xsl:apply-templates select="comentario"/>
					</DIV>
				</xsl:for-each>
			</BODY>
		</HTML>
	</xsl:template>
	
	<xsl:template match="comentario">
		<xsl:for-each select="comentario">
			<P class="comentario"><STRONG>Comentario: </STRONG><xsl:value-of select="."/></P>
		</xsl:for-each>
	</xsl:template>
	
	<xsl:template match="artistas">
	
		<xsl:for-each select="artista">
			<P class="artista"><STRONG>Artista: </STRONG><xsl:value-of select="."/></P>
		</xsl:for-each>
	</xsl:template>

</xsl:stylesheet>