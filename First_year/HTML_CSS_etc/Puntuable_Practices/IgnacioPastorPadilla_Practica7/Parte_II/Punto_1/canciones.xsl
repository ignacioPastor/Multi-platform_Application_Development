<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="/">
		<HTML>
		<BODY>
		<H1>Repositorio de canciones</H1>
		<xsl:for-each select="//cancion">
			<H2>Título de la canción: <xsl:value-of select="@titulo"/></H2>
			<xsl:apply-templates select="artistas"/>
			<xsl:if test="@genero">
				<P>Género: <xsl:value-of select="@genero"/></P>
			</xsl:if>
			<P>Album: <xsl:value-of select="album"/></P>
			<P>Año: <xsl:value-of select="anyo"/></P>
			<P>Ubicación: <xsl:value-of select="ubicacion"/></P>
			<xsl:apply-templates select="comentario"/>
		</xsl:for-each>
		</BODY>
		</HTML>
	</xsl:template>
	
	<xsl:template match="comentario">
		<xsl:for-each select="comentario">
			<P>Comentario: <xsl:value-of select="."/></P>
		</xsl:for-each>
	</xsl:template>
	
	<xsl:template match="artistas">
	
		<xsl:for-each select="artista">
			<P>Artista: <xsl:value-of select="."/></P>
		</xsl:for-each>
	</xsl:template>

</xsl:stylesheet>