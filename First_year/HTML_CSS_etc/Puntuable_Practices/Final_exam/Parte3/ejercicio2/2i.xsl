<?xml version="1.0" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" indent="yes"/>
	<xsl:template match="/">
	<lenguajes>
		<xsl:for-each select="//lenguaje">
			<lenguaje><xsl:value-of select="nombre"/></lenguaje>
		</xsl:for-each>
	</lenguajes>
		
		
	</xsl:template>
</xsl:stylesheet>