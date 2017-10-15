<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<html>
		<body>
			<h1>Lenguajes de programación</h1>
			<xsl:for-each select="//lenguaje">
				<p>
					<xsl:value-of select="creador"/>
					<xsl:text> creó el lenguaje </xsl:text>
					<xsl:value-of select="nombre"/>
					<xsl:text> en </xsl:text>
					<xsl:value-of select="fecha"/>
					<xsl:text>.</xsl:text>
				</p>
			</xsl:for-each>
		</body>
		</html>
		
	</xsl:template>
</xsl:stylesheet>