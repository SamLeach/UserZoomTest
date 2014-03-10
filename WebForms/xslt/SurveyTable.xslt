<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="html" encoding="UTF-8" omit-xml-declaration="yes" media-type="text/html"/>
  <xsl:template  match="/root/surveys">
    <xsl:text>Surveys: </xsl:text>

    <table width="400" border="1" >
      <tr bgcolor = "#cccccc" >
        <td>Study Title</td>
        <td>Survey Title</td>
        <td>Completes</td>
        <td>Needed</td>
        <td>Participants Needed</td>
      </tr>
      <xsl:for-each select="data" >
        <tr>
          <td>
            <xsl:value-of select="studyTitle" />
          </td>
          <td>
            <xsl:value-of select="surveyTitle" />
          </td>
          <td>
            <xsl:value-of select="completes" />
          </td>
          <td>
            <xsl:value-of select="needed" />
          </td>
          <td>
            <xsl:value-of select="participantsNeeded" />
          </td>
        </tr>
      </xsl:for-each>
    </table>
       
  </xsl:template>
</xsl:stylesheet>
