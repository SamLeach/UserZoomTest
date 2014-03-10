<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="html" encoding="UTF-8" omit-xml-declaration="yes" media-type="text/html"/>
  <xsl:template  match="/root">
    <xsl:text>The total of tasks are: </xsl:text>
    <input type="text" name="txtTotalTasks" size="5" maxlength="2" disabled="disabled">
      <xsl:attribute name="value"><xsl:value-of select="tasks/data/total"/></xsl:attribute>
    </input>
    <div id="warn-limit" class="uz-warning uz-hidden"> You have reached the limited of your account</div>
  </xsl:template>
</xsl:stylesheet>
