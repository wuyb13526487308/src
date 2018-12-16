<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <Templates>
      <xsl:for-each select="//Templates/*">
        <Template Name="{@Name}" ImageUrl="{ImageUrl}" Description="{Description}" Html="{Html}"></Template>
      </xsl:for-each>
    </Templates>
  </xsl:template>
</xsl:stylesheet>